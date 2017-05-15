using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace PlugIns
{
    //esse PluginType deve ser a classe abstrata da qual o plugin é filha.
    public abstract class PlugInManager<PluginType>: iPlugInManager<PluginType>
    {


        protected string plugInDir;
        protected List<iPlugin> plugIns;
        protected Configuration config;     

        public PlugInManager(string baseConfigFile,string baseDir)
        {

            if (!File.Exists(baseConfigFile)) {
                File.WriteAllLines(baseConfigFile, new string[5] {
                    "<?xml version = \"1.0\" encoding = \"utf-8\"?>",
                    "<configuration>",
                    "\t<appSettings>",
                    "\t</appSettings>",
                    "</configuration>",
                });
            }          

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = baseConfigFile; // full path to the config file

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["pluginDir"] == null)
            {
                config.AppSettings.Settings.Add("pluginDir", baseDir);
                config.Save(ConfigurationSaveMode.Modified);
                
            }

            plugInDir = config.AppSettings.Settings["pluginDir"].Value;

            if (!Directory.Exists(plugInDir)) 
            Directory.CreateDirectory(plugInDir);
        }
        public void Load()
        {
            plugIns = null;
            plugIns = new List<iPlugin>();
            if (Directory.Exists(plugInDir))
            {
                // This path is a directory
                string[] files = Directory.GetFiles(plugInDir);
                foreach (string file in files)
                {

                    AssemblyName assemblyName;
                    Assembly assembly;
                    Type[] types;
                    try
                    {
                        assemblyName = AssemblyName.GetAssemblyName(file);
                        assembly = Assembly.Load(assemblyName);
                        types = assembly.GetTypes();
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (types.Length != 1)
                    {
                        continue;
                    }
                    Type pluginType = types.ElementAt(0);

                    
                    if (pluginType.GetInterfaces().Contains(typeof(iPlugin)) == false)
                    {                        
                        continue;//não é plugin.
                    }
                    if (pluginType.BaseType != typeof(PluginType))
                    {                        
                        continue; //não é do tipo específico deste gerenciador.
                    }

                    iPlugin plugIn = (iPlugin)Activator.CreateInstance(pluginType);
                    pluginType = null;
                    types = null;

                    if (plugIns.Find(x => x.Identifier.Equals(plugIn.Identifier)) != null)
                    {
                        plugIn = null;
                        continue;
                    }
                    
                    string strategyConfig = "plugin_" + plugIn.Identifier;
                    if (config.AppSettings.Settings[strategyConfig] == null)
                    {
                        config.AppSettings.Settings.Add(strategyConfig, "1");
                        config.Save(ConfigurationSaveMode.Modified);
                    }

                    string active = config.AppSettings.Settings[strategyConfig].Value;

                    if (active.Equals("1"))
                    {
                        plugIn.Active = true;
                    }
                    else
                    {
                        plugIn.Active = false;
                    }

                    plugIns.Add(plugIn);
                    
                }
            }
            else
            {

            }
        }

        public List<iPlugin> All
        {
            get
            {
                return plugIns;
            }
        }

        public Configuration Config
        {
            get
            {
                return config;
            }
        }

        public void SetState(iPlugin plugin, bool newState)
        {

            iPlugin target = plugIns.Find(x => x.Identifier.Equals(plugin.Identifier));
            if (target != null)
            {
                target.Active = newState;
                config.AppSettings.Settings["plugin_" + target.Identifier].Value = newState ? "1" : "0";
                config.Save(ConfigurationSaveMode.Modified);

            }            
        }
        public void SetState(string identifier, bool newState)
        {
            iPlugin target = plugIns.Find(x => x.Identifier.Equals(identifier));
            if (target != null)
            {
                target.Active = newState;
                config.AppSettings.Settings["plugin_" + target.Identifier].Value = newState ? "1" : "0";
                config.Save(ConfigurationSaveMode.Modified);

            }
        }
        public PluginType Get(string identifier)
        {
            return (PluginType)plugIns.Find(x => x.Identifier.Equals(identifier));
        }
        public PluginType Get(int index)
        {
            return (PluginType)plugIns.ElementAt(index);
        }
    }
}
