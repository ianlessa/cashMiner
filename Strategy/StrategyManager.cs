using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using PlugIns;

namespace Strategy
{
    public class StrategyManager : PlugInManager<Strategy>
    {
        public StrategyManager() : base("strategy.config", "strategy")
        {
        }



        /*
        private string strategyDir;
        private List<iStrategy> strategies;
        private Configuration config;

        public StrategyManager()
        {


            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = "strategy.config"; // full path to the config file

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);
            if(config.AppSettings.Settings["strategyDir"] == null)
            {
                config.AppSettings.Settings.Add("strategyDir", "strategy");
                config.Save(ConfigurationSaveMode.Modified);
            }

            strategyDir = config.AppSettings.Settings["strategyDir"].Value;


            if (!Directory.Exists(strategyDir)) 
            Directory.CreateDirectory(strategyDir);
        }

        public void Load()
        {
            strategies = null;
            strategies = new List<iStrategy>();
            if (Directory.Exists(strategyDir))
            {
                // This path is a directory
                string[] files = Directory.GetFiles(strategyDir);
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
                    Type strategyType = types.ElementAt(0);

                    if (strategyType.GetInterfaces().Contains(typeof(iStrategy)) == false)
                    {
                        continue;
                    }

                    iStrategy strategy = (iStrategy)Activator.CreateInstance(strategyType, file);
                    strategyType = null;
                    types = null;

                    if (strategies.Find(x => x.Identifier.Equals(strategy.Identifier)) != null)
                    {
                        strategy = null;
                        continue;
                    }


                    if (strategy.Load())
                    {

                        string strategyConfig = "strategy_" + strategy.Identifier;
                        if (config.AppSettings.Settings[strategyConfig] == null)
                        {
                            config.AppSettings.Settings.Add(strategyConfig, "1");
                            config.Save(ConfigurationSaveMode.Modified);
                        }

                        string active = config.AppSettings.Settings[strategyConfig].Value;

                        if (active.Equals("1"))
                        {
                            strategy.Active = true;
                        }
                        else
                        {
                            strategy.Active = false;
                        }

                        strategies.Add(strategy);
                    }
                }
            }
            else
            {

            }
        }
        public List<iStrategy> Strategies
        {
            get
            {
                return strategies;
            }
        }
        public void SetStrategyState(iStrategy strategy, bool newState)
        {
            iStrategy target = strategies.Find(x => x.Identifier.Equals(strategy.Identifier));
            if (target != null)
            {
                target.Active = newState;
                config.AppSettings.Settings["strategy_" + target.Identifier].Value = newState ? "1" : "0";
                config.Save(ConfigurationSaveMode.Modified);

            }

        }
        public void SetStrategyState(string strategyIdentifier, bool newState)
        {
            iStrategy target = strategies.Find(x => x.Identifier.Equals(strategyIdentifier));
            if (target != null)
            {
                target.Active = newState;
                config.AppSettings.Settings["strategy_" + target.Identifier].Value = newState ? "1" : "0";
                config.Save(ConfigurationSaveMode.Modified);

            }

        }
        public iStrategy getStrategyByIdentifier(string strategyIdentifier)
        {
            return strategies.Find(x => x.Identifier.Equals(strategyIdentifier));
        }
        
        */

    }
}
