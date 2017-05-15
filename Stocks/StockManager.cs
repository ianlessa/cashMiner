using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace Stocks
{
    public class StockManager
    {
        private Dictionary<int,Stock> stockListById;
        private Dictionary<string,Stock> stockListByTicker;
        private List<Stock> stockList;
        private DBConnection DB;


        public StockManager(DBConnection DB)
        {
            this.DB = DB;
        }

        

        public Stock Get(int stockId)
        {
            Stock result = null;
            if (stockListById == null)
                return null;

            stockListById.TryGetValue(stockId,out result);
            return result;
        }

        public Stock Get(string ticker)
        {
            Stock result = null;
            if (stockListByTicker == null)
                return null;

            stockListByTicker.TryGetValue(ticker, out result);
            return result;
        }

        public List<Stock> All
        {
            get
            {
                return stockList;
            }
        }

        public void Add(Stock stock)
        {
            stock.CreateHistoricalData(DB);
            if (stockList == null)
            {
                stockList = new List<Stock>();
                stockListById = new Dictionary<int, Stock>();
                stockListByTicker = new Dictionary<string, Stock>();
            }
            stockList.Add(stock);
            stockListById.Add(stock.Id, stock);
            stockListByTicker.Add(stock.Ticker, stock);
        }


    }
}
