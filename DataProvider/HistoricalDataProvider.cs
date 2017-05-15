using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candles;

namespace DataProviders
{
    public abstract class HistoricalDataProvider : DataProvider<Candle>
    {
        public HistoricalDataProvider(string name, string identifier) : base(name, identifier)
        {






        }
        
    }
}
