using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DataProviders;
using Candles;



namespace GoogleFinance
{
    public class GoogleFinance : HistoricalDataProvider
    {

        private HttpClient client;
        private string url;     

        public GoogleFinance() : base ("Google Finance","GOOGLE_FINANCE")
        {
           
        }


        public override bool Authenticate(string username, string password)
        {          
            authenticated = true;
            return true;
        }


        /// <summary>
        /// Conecta ao google finance e recupera os dados históricos.
        /// <para>database: exchange</para>
        /// <para>dataId : ticker</para>
        /// <para>resolutin: em seconds</para>
        /// <para>maxPeriods: auto-explicativo.</para>
        /// </summary>
        public override List<Candle> GetAllFrom(string database, string dataId, int resolution, string maxPeriods)
        {
                        
            string resultData;
            string[] lines;
            string[] lineData;
            long currentTimestamp = 0;
            DateTime currentDateTime;
            DateTime candleDateTime;
            List<Candle> result = new List<Candle>();

            url = "http://www.google.com/finance/getprices?f=d,c,v,o,h,l&df=cpct&auto=0&ei=Ef6XUYDfCqSTiAKEMg";
            url += "&x=" + database;
            url += "&q=" + dataId;
            url += "&i=" + resolution;
            url += "&p=" + maxPeriods;

            if (client == null)
                client = new HttpClient();


            HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                resultData = response.Content.ReadAsStringAsync().Result;
                resultData = resultData.Replace(",", "@");
                resultData = resultData.Replace(".", ",");
                lines = resultData.Split('\n');
                
                //8 linhas de cabeçalho, no min
                if (lines.Length > 7)
                {                    
                    currentDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                  
                    for (int i = 7; i < lines.Length; i++)
                    {                       
                        lineData = lines[i].Split('@');
                        if (lineData.Length != 6)
                            continue;
                        
                        if (lineData[0].Contains("a")) //nova timestamp;
                        {
                            currentTimestamp = long.Parse(lineData[0].Replace("a", "")); 
                            currentDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);                          
                            currentDateTime = currentDateTime.AddSeconds(currentTimestamp).ToLocalTime();
                            currentTimestamp = GoogleFinance.ConvertToUnixTime(currentDateTime);
                            continue; //não adicionar linha 
                        }
                        candleDateTime = currentDateTime.AddSeconds(resolution * long.Parse(lineData[0]));

                        // public Candle(int size, long timestamp, float open, float close, float high, float low, float volume)
                        //CLOSE,HIGH,LOW,OPEN,VOLUME

                        //adicionar novo objeto com os dados da linha.
                        result.Add(new Candle(
                            resolution,
                            GoogleFinance.ConvertToUnixTime(candleDateTime),
                            float.Parse(lineData[4]),
                            float.Parse(lineData[1]),
                            float.Parse(lineData[2]),
                            float.Parse(lineData[3]),
                            float.Parse(lineData[5])
                       ));                     
                    }
                }               
            }            
            return result;                       
        }

        public override List<Candle> GetAllFrom(string database, string dataId, int resolution)
        {
            return GetAllFrom(database, dataId, resolution, "100Y");
        }



        //helpers
        private static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }

        public string LastUrl
        {
            get
            {
                return url;
            }
        }


        //não oferece suporte.
        public override List<Candle> GetAllFrom(string dataId, int resolution)
        {
            return null;
        }
        public override List<Candle> GetAllFrom(int dataId, int resolution)
        {
            return null;              
        }




    }
}
