using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candles;
using DB;

namespace Stocks
{
    public class stockCandleManager
    {
        private Stock stock;
        private CandleManager candleManager;
        public stockCandleManager(DBConnection DB, Stock stock)
        {
            this.stock = stock;
            candleManager = new CandleManager(DB);
        }

        public void CreateList(int periodLength) {
            candleManager.CreateList(stock.Id, periodLength);
        }
        public void SetList(int periodLength, List<Candle> candleList) {
            candleManager.SetList(stock.Id, periodLength, candleList);
        }
        public void AddCandle(int periodLength, Candle candle) {
            candleManager.AddCandle(stock.Id, periodLength, candle);
        }
        public List<Candle> GetCandleList( int periodLength) {

            return candleManager.GetCandleList(stock.Id, periodLength);

        }
        public void ClearAll() {
            candleManager.ClearAll();
        }
        public void LoadFromDB( int periodLength) {
            candleManager.LoadFromDB(stock.Id, periodLength);
        }
        public void ReloadAllFromDb() {
            candleManager.ReloadAllFromDb();
        }

    }
}
