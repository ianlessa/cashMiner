using System;
using System.Collections.Generic;
using Candles;
using DB;

namespace Stocks
{
    public class Stock
    {
        private int id;
        private string name;
        private string ticker;
        
        private stockCandleManager historicalData;

        public Stock(int id, string name, string ticker)
        {
            this.id = id;
            this.name = name;
            this.ticker = ticker;
            //historicalData = new CandleManager();
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get {


                return name.Length > 0 ? name : "(" + ticker + ") : Nome vazio"; 





            } set { name = value; } }
        public string Ticker { get { return ticker; } set { ticker = value; } }
        
        public void CreateHistoricalData(DBConnection DB)
        {
            if (historicalData == null)
            {
                historicalData = new stockCandleManager(DB,this);
            }
        }


        public void CreateHistoricalDataList(int resolution)
        {
            historicalData.SetList(resolution, new List<Candle>());
        }

        public List<Candle> HistoricalData(int resolution)
        {            
            return historicalData.GetCandleList(resolution);
        }

        public stockCandleManager HistoricalDataManager
        {
            get
            {
                return historicalData;
            }
        }

    }
}
