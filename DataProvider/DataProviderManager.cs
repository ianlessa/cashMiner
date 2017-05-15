using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using PlugIns;

namespace DataProviders
{
    public class DataProviderManager<PluginType> : PlugInManager<PluginType>
    {
      
        public DataProviderManager() : base("dataProvider.config", "dataProviders")
        {}

    }
}
