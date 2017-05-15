using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProviders;
using Candles;
using DB;

namespace DBHistoricalProvider 
{
    public class DBHDProvider : HistoricalDataProvider
    {
        DBConnection DB;


        public DBHDProvider() : base("Banco de Dados", "DB_HISTORICAL_PROVIDER")
        {
            DB = new DBConnection("localhost", "stockbot", "root", "root");
        }

        public override bool Authenticate(string username, string password)
        {
            authenticated = true;
            return true;
        }

        public override List<Candle> GetAllFrom(string dataId, int resolution)
        {
            throw new NotImplementedException();
        }

        public override List<Candle> GetAllFrom(int dataId, int resolution)
        {

          
            CandleManager cm = new CandleManager(DB);
            cm.LoadFromDB(dataId, resolution);
            return cm.GetCandleList(dataId, resolution);
           
        }
       

        public override List<Candle> GetAllFrom(string database, string dataId, int resolution)
        {
          
            CandleManager cm = new CandleManager(DB);
            int id = cm.LoadFromDB(dataId, resolution);
            return cm.GetCandleList(id, resolution);
        }

        public override List<Candle> GetAllFrom(string database, string dataId, int resolution, string maxPeriods)
        {
            return GetAllFrom( database,  dataId,  resolution);
        }
    }
}

