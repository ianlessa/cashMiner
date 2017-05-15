using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using DB;
using System.Windows.Forms;

namespace Candles
{
    public class CandleManager
    {

        private Dictionary<string, List<Candle>> CandleLists;
        private DBConnection DB;

        public CandleManager(DBConnection DB)
        {
            CandleLists = new Dictionary<string, List<Candle>>();
            this.DB = DB;
        }


        public void CreateList(int stockId, int periodLength)
        {
            SetList(stockId, periodLength, new List<Candle>());
        }

        public void SetList(int stockId, int periodLength, List<Candle> candleList)
        {
            List<Candle> result;
            string listName = PrepareListName(stockId, periodLength);
            CandleLists.TryGetValue(listName, out result);
            if(result == null)
            {
                CandleLists.Add(listName, candleList);
            }
            else
            {               
                CandleLists.Remove(listName);
                CandleLists.Add(listName, candleList);                
            }
        }

        public void AddCandle(int stockId, int periodLength, Candle candle)
        {
            List<Candle> result;
            string listName = PrepareListName(stockId, periodLength);           
            CandleLists.TryGetValue(listName, out result);
            if (result == null)
            {
                result = new List<Candle>();
                CandleLists.Add(listName, result);
            } 
            result.Add(candle);
        }

        public List<Candle> GetCandleList(int stockId, int periodLength)
        {
            List<Candle> result = new List<Candle>();
            string listName = PrepareListName(stockId, periodLength);
            CandleLists.TryGetValue(listName, out result);
            return result;
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)] //isso aqui eh pra ficar inline.
        public static string PrepareListName(int stockId, int periodLength)
        {
            return stockId + "_" + periodLength;
        }


        public void ClearAll()
        {
            foreach (KeyValuePair<string, List<Candle>> list in CandleLists)
                list.Value.Clear();
        }

        public void LoadFromDB(int stockId, int periodLength)
        {
            
            string query = "SELECT * FROM period WHERE stock_id = " + stockId + " AND periodLength = " + periodLength;
            string listName = PrepareListName(stockId, periodLength);
            List<string>[] results = DB.Select(query);
            List<Candle> candleList = new List<Candle>();

            int i;
            for (i = 0; i < results[1].Count; i++)
            {
                //Clipboard.SetText(results[2][i]);
                candleList.Add(new Candle(
                    periodLength,
                    long.Parse(results[1][i]),
                    float.Parse(results[3][i].Replace(".", ",")),
                    float.Parse(results[4][i].Replace(".", ",")),
                    float.Parse(results[5][i].Replace(".", ",")),
                    float.Parse(results[6][i].Replace(".", ",")),
                    float.Parse(results[7][i].Replace(".", ","))
                ));
            }
        
            SetList(stockId, periodLength, candleList);
        }

        public int LoadFromDB(string ticker, int periodLength)
        {
            string query = "SELECT id FROM stock WHERE ticker = '" + ticker + "'";
            List<string>[] results = DB.Select(query);
            if(results[0].Count > 0)
            {
                LoadFromDB(int.Parse(results[0][0]), periodLength);
                return int.Parse(results[0][0]);
            }
            return -1;
        }

        public void ReloadAllFromDb()
        {
            string[] temp;

            List<string> keys = new List<string>();
            foreach (KeyValuePair<string, List<Candle>> list in CandleLists)            
                keys.Add(list.Key);                                    

            ClearAll();

            foreach(String key in keys)
            {
                temp = key.Split('_');
                LoadFromDB(int.Parse(temp[0]), int.Parse(temp[1]));
            };
        }

    }
}
