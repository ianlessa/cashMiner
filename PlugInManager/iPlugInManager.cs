using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PlugIns
{
    public interface iPlugInManager<PluginType>
    {
        void Load();
        List<iPlugin> All { get ; }

        void SetState(iPlugin plugin, bool newState);
        void SetState(string identifier, bool newState);
        PluginType Get(string identifier);        
        PluginType Get(int index);

        Configuration Config { get; }
    }
}
