using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Strategy;
using System.Net.Http;
using System.Threading;
using DB;
using Stocks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using GoogleFinance;
using Candles;
using DataProviders;
using CefSharp;


namespace Monitor
{
    public class AppData
    {

        private static bool loadDone;
        private static Thread loadThread = null;        
        public Configuration config;
        public Dictionary<string, bool> historicalDataResolutions;
        public Dictionary<int, string> historicalResolutionSource;


        public DBConnection DB;
        public RTDStream.StreamerClient streamerClient;
        public RTDStream.RtdStreamerListener rtdStreamListener;
        public StrategyManager strategyManager;
        public StockManager stockManager;
        public DataProviderManager<HistoricalDataProvider> historicalDataManager;
        public bool isStreaming;
        public CefSettings CEFsettings;


        //public CandleManager candleManager;

        //public BootstrapForm bootstrap;
        public RTDLogin rtdLogin;
        public MainForm mainForm;
  
        public AppData()
        {
            //AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile; // full path to the config file

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            isStreaming = false;
        }


        public void SaveConfig()
        {           
            /*
            config.Save(ConfigurationSaveMode.Modified);                //ta lançando exceção.
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            */
        }

        public void Load()
        {
            // Make sure it is only launched once.
            if (loadThread != null)
                return;

            loadDone = false;

            loadThread = new Thread(_load);
            loadThread.IsBackground = true;
            loadThread.SetApartmentState(ApartmentState.STA);
            loadThread.Start();
            //bootstrap.Debug("treadIniciada\n", true);
            while (!loadDone)
            {                
                //bootstrap.Update();
                Thread.Sleep(500);
            }
            // bootstrap.Debug("pronto\n", true);
            rtdLogin = new RTDLogin(this);
            mainForm = new MainForm(this);

            //iniciando CEF
            CEFsettings = new CefSettings();
            CEFsettings.RemoteDebuggingPort = 8088;
            Cef.Initialize(CEFsettings, performDependencyCheck: false, browserProcessHandler: null);

        }


        private void _load()
        {



            BootstrapForm bootstrap = new BootstrapForm(this);
            bootstrap.Show();
            
            CreateDB(bootstrap);//objeto de acesso ao banco de dados.


            //inicializando StockManager
            LoadStockManager(bootstrap);
            //atualizando Logos
            UpdateLogos(bootstrap);
            //inicializando DataProviderManager
            historicalDataManager = new DataProviderManager<HistoricalDataProvider>();
            historicalDataManager.Load();
            //carregando bases históricas;
            LoadHistoricalData(bootstrap);
            //carregando RTDStreamer
            LoadRTDData(bootstrap);
            //carregar estratégias
            LoadStrategyManager(bootstrap);

          

            loadDone = true;
        }


        private void CreateDB(BootstrapForm bootstrap) //deve ser inline.
        {
            DB = new DBConnection(
             ConfigurationManager.AppSettings["databaseHost"],
             ConfigurationManager.AppSettings["databaseName"],
             ConfigurationManager.AppSettings["databaseUid"],
             ConfigurationManager.AppSettings["databasePassword"]
           );

            try
            {
                DB.testConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Application.Exit();
            };
        }
        private void LoadStockManager(BootstrapForm bootstrap)
        {
            bootstrap.MainLabel = "Inicializando Gerenciador de Ações...";

            stockManager = new StockManager(DB);

            List<string>[] results = DB.Select("select * from stock where id <= 10");
         
            for (int i = 0; i < results[1].Count; i++)            
                stockManager.Add(new Stock(int.Parse(results[0][i]), results[2][i], results[1][i]));            
        }
        private void UpdateLogos(BootstrapForm bootstrap)
        {
            bootstrap.MainLabel = "Autualizando logos de empresas...";

            WebClient downloader = new WebClient();
            string logoDir = config.AppSettings.Settings["logoDir"].Value;

            if (!Directory.Exists(logoDir))
                Directory.CreateDirectory(logoDir);




            string[] files = Directory.GetFiles(logoDir);
            List<string> logoList = new List<string>();                                    
            foreach (string file in files)
            {                
                logoList.Add(
                    Regex.Replace(file.Split('.')[0].Split('\\')[1], "[0-9]", "")
                );
            }


            bootstrap.SubProgress = 0;
            bootstrap.SubProgressMax = stockManager.All.Count;
            foreach (Stock stock in stockManager.All)
            {
                if (logoList.Contains(Regex.Replace(stock.Ticker, "[0-9]", "")) == false) //precisa autualizar logo.
                {
                    bootstrap.SubLabel = "Obtendo logo de " + stock.Name;
                    downloader.DownloadFile(
                        "http://br.advfn.com/common/images/companies/BOV_" + stock.Ticker + ".png",
                         logoDir + "/" + Regex.Replace(stock.Ticker, "[0-9]", "") + ".png"
                    );
                }
                bootstrap.SubProgress++;
            }
              
        }
        private void LoadHistoricalData(BootstrapForm bootstrap)
        {
            historicalDataResolutions = new Dictionary<string, bool>();
            historicalResolutionSource = new Dictionary<int, string>();
            if (historicalDataManager.All.Count > 0) 
            {

                //historicalDataResolutions = new Dictionary<string, bool>();
                //historicalResolutionSource = new Dictionary<int, string>();
                string temp;

                bootstrap.MainLabel = "Carregando Bases Históricas...";

                if (historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"] == null)
                {
                    historicalDataManager.Config.AppSettings.Settings.Add("historicalDataProvider", historicalDataManager.All[0].Identifier);
                    historicalDataManager.Config.Save(ConfigurationSaveMode.Modified);
                }

                HistoricalDataProvider database = historicalDataManager.Get("DB_HISTORICAL_PROVIDER");
                HistoricalDataProvider updater = historicalDataManager.Get(historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"].Value);

            
                foreach (KeyValueConfigurationElement configValue in historicalDataManager.Config.AppSettings.Settings)
                {
                    //bootstrap.Debug(configValue.Key + "\n", true);
                    if (configValue.Key.Contains("HistoricalDataResolution_"))
                    {
                        historicalDataResolutions.Add(configValue.Key.Split('_')[1], configValue.Value == "1" ? true : false);
                    }
                }
                List<int> resolutions = new List<int>();
                foreach (KeyValuePair<string, bool> entry in historicalDataResolutions)
                {                 
                    if (entry.Value)
                    {
                        int tmp = HistoricalDataResolutionStringToSeconds(entry.Key);                      
                        historicalResolutionSource.Add(tmp, entry.Key);
                        resolutions.Add(tmp);
                    }
                }

                bootstrap.SubProgress = 0;
                bootstrap.SubProgressMax = stockManager.All.Count * resolutions.Count;


                bool updateNeeded;
                bool autoUpdate = false;
                string query;
                StringBuilder sb;
                List<string>[] results;
                DateTime lastWeekDay = DateTime.Now;
                //new DateTime(1970,1,1,1,);
                lastWeekDay = new DateTime(lastWeekDay.Year, lastWeekDay.Month, lastWeekDay.Day,17, 0, 0);
                //pra pegar o ultimo dia útil.
                while(lastWeekDay.DayOfWeek == DayOfWeek.Sunday || lastWeekDay.DayOfWeek == DayOfWeek.Saturday)
                    lastWeekDay = lastWeekDay.Subtract(TimeSpan.FromDays(1));
            
                if (historicalDataManager.Config.AppSettings.Settings["historicalDataAutoUpdate"] == null)
                {
                    historicalDataManager.Config.AppSettings.Settings.Add("historicalDataAutoUpdate", "0");
                    historicalDataManager.Config.Save(ConfigurationSaveMode.Modified);
                }

                if(historicalDataManager.Config.AppSettings.Settings["historicalDataAutoUpdate"].Value == "1")
                {
                    autoUpdate = true;
                }
                


                foreach (Stock stock in stockManager.All)
                {
                    foreach(int resolution in resolutions)
                    {
                        //checar se os dados históricos estão atualizados.
                        
                        query = "SELECT timestamp FROM period WHERE stock_id = ";
                        query += stock.Id + " AND periodLength = " + resolution;
                        query += " ORDER BY timestamp DESC LIMIT 1";
                        updateNeeded = false;
                        results = DB.Select(query);

                        if (results[0].Count == 0)  //se não tiver nada no bd
                            updateNeeded = true;
                        else
                        { 
                            DateTime lastUpdateDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                            lastUpdateDateTime = lastUpdateDateTime.AddSeconds(long.Parse(results[0][0]));



                            if (lastUpdateDateTime.AddDays(1).DayOfWeek == DayOfWeek.Saturday)
                            { //ultimo foi sexta 
                                //Clipboard.SetText(lastWeekDay.AddDays(2).Day.ToString());
                                if ((lastWeekDay.AddDays(1) - lastUpdateDateTime).TotalDays >= 1)
                                    updateNeeded = true;
                            }
                            else if ((lastWeekDay - lastUpdateDateTime).TotalHours >= 1) //se o ultimo periodo do db for de um dia anterior a ontem, atualizar.
                                    updateNeeded = true;
                            
                        }

                        historicalResolutionSource.TryGetValue(resolution, out temp);
                        if (updateNeeded && autoUpdate) //precisa atualizar
                        {                         
                            bootstrap.SubLabel = "Baixando dados históricos para " + stock.Ticker + ":" +
                                temp + " de " + updater.Name + "...";

                            stock.HistoricalDataManager.SetList(resolution,
                                updater.GetAllFrom("BVMF", stock.Ticker, resolution)
                            );



                            if (stock.HistoricalDataManager.GetCandleList(resolution).Count > 0)
                            {

                                bootstrap.SubLabel = "Atualizando dados históricos de " + stock.Ticker + ":" + temp + "...";

                                sb = new StringBuilder();
                                sb.Append("INSERT INTO period VALUES ");
                                foreach (Candle candle in stock.HistoricalData(resolution))
                                {
                                    sb.Append(
                                          "(" +
                                          stock.Id + ";" +
                                          candle.Timestamp + ";" +
                                          resolution + ";" +
                                          candle.Open + ";" +
                                          candle.Close + ";" +
                                          candle.High + ";" +
                                          candle.Low + ";" +
                                          candle.Volume + ");"
                                   );
                                }

                                query = sb.ToString();
                                query = query.Replace(",", ".");
                                query = query.Replace(";", ",");
                                query += "@@@";
                                query = query.Replace(",@@@", " ON DUPLICATE KEY UPDATE stock_id=stock_id");
                                DB.Query(query);
                            }
                            
                        }


                        bootstrap.SubLabel = "Carregando dados históricos para " + stock.Ticker + ":" +
                               temp + " de " + database.Name + "...";
                        stock.HistoricalDataManager.SetList(
                            resolution,
                            database.GetAllFrom(stock.Id, resolution)
                        );

                        bootstrap.SubProgress++;
                    }

                }  
            }
        }
        private void LoadRTDData(BootstrapForm bootstrap)
        {
            bootstrap.MainLabel = "Iniciando RTD...";
            List<String> tempTickers = new List<string>();
            foreach (Stock stock in stockManager.All)
                tempTickers.Add(stock.Ticker);
            rtdStreamListener = new RTDStream.RtdStreamerListener();
            streamerClient = new RTDStream.StreamerClient(rtdStreamListener, tempTickers);
        }
        private void LoadStrategyManager(BootstrapForm bootstrap)
        {
            bootstrap.MainLabel = "Iniciando Gerenciador de Estratégias...";
            strategyManager = new StrategyManager();
            strategyManager.Load();
        }



        private void _loadBACK()
        {

            

            BootstrapForm bootstrap = new BootstrapForm(this);
            bootstrap.Show();


            /*
            GoogleFinance.GoogleFinance googleFinance = new GoogleFinance.GoogleFinance();    
            List<Candle> test = googleFinance.GetAllFrom("BVMF", "ABEV3", 3600, "1d");

            Clipboard.SetText("empty");
            foreach (Candle candle in test)
            {
                bootstrap.Debug(candle.DateTime + "\n", true);
            }
                       

            return;
            */

            /*
                        bootstrap.Close();

                        loadDone = true;            
                        return;
                        */

            //criando o objeto de banco de dados
            DB = new DBConnection(
            ConfigurationManager.AppSettings["databaseHost"],
            ConfigurationManager.AppSettings["databaseName"],
            ConfigurationManager.AppSettings["databaseUid"],
            ConfigurationManager.AppSettings["databasePassword"]
          );

            try
            {
                DB.testConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Application.Exit();
            };


            //criando o cliente de stream.
            HttpClient client = new HttpClient();
            WebClient downloader = new WebClient();
            string tmpUrl;
            string logoDir = config.AppSettings.Settings["logoDir"].Value; 
            string[] files = Directory.GetFiles(logoDir);
            List<string> logoList = new List<string>();
            foreach(string file in files)
            {
                tmpUrl = file.Split('.')[0];
                tmpUrl = tmpUrl.Split('\\')[1];
                logoList.Add(Regex.Replace(tmpUrl, "[0-9]", ""));               
            }
            
            rtdStreamListener = new RTDStream.RtdStreamerListener();
            //carregando a lista de ações.
            stockManager = new StockManager(DB);
            List<string> tickers = new List<string>();
            //stockIdByTicker = new Dictionary<string, int>();
            List<string>[] results = DB.Select("select * from stock where id <= 300");
            Stock tmpStock;
            //string tmpUrl;
            bootstrap.MainLabel = "Atualizando Logos de empresas...";
            float totalData;
            float currentData;
            bootstrap.SubProgressMax = results[1].Count;
            currentData = 0;
            bootstrap.SubProgress = 0;
            for (int i = 0; i < results[1].Count; i++)
            {
                // Console.WriteLine("Adicionando {0}", results[1][i]);
                tickers.Add(results[1][i]);
                //stockIdByTicker.Add(results[1][i], int.Parse(results[0][i]));  
                tmpStock = new Stock(int.Parse(results[0][i]), results[2][i], results[1][i]);
                stockManager.Add(tmpStock);
                               
                //bootstrap.SubProgress = (int)((currentData / totalData) * 100);
                if (logoList.Contains(Regex.Replace(tmpStock.Ticker, "[0-9]", "")) == false) //precisa autualizar logo.
                {

                    bootstrap.SubLabel = "Obtendo logo de " + tmpStock.Name;
                    tmpUrl = "http://br.advfn.com/common/images/companies/BOV_" + tmpStock.Ticker + ".png";
                    
                    downloader.DownloadFile(tmpUrl, logoDir + "/" + Regex.Replace(tmpStock.Ticker, "[0-9]", "") + ".png");
                }
                bootstrap.SubProgress = (int)++currentData;
            }
            streamerClient = new RTDStream.StreamerClient(rtdStreamListener, tickers);
            bootstrap.SubProgress = 0;
            bootstrap.SubProgressMax = 100;
            //inicializando o gerenciador de estratégias.
            strategyManager = new StrategyManager();
            strategyManager.Load();


//inicializando as bases históricas.


            //candleManager = new CandleManager(DB);
            historicalDataResolutions = new Dictionary<string, bool>();
            historicalResolutionSource = new Dictionary<int, string>();
            //config.AppSettings.Settings
            foreach (KeyValueConfigurationElement configValue in config.AppSettings.Settings)
            {
                //bootstrap.Debug(configValue.Key + "\n", true);
                if (configValue.Key.Contains("HistoricalDataResolution_")){
                    
                    historicalDataResolutions.Add(configValue.Key.Split('_')[1], configValue.Value == "1" ? true : false);
                }                
            }
            List<int> resolutions = new List<int>();
            foreach (KeyValuePair<string, bool> entry in historicalDataResolutions)
            {
               // bootstrap.Debug(entry.Key + "\n", true);
                if (entry.Value)
                {
                    int tmp = HistoricalDataResolutionStringToSeconds(entry.Key);
                    //bootstrap.Debug(tmp + ":" + entry.Key + "\n", true);
                    historicalResolutionSource.Add(tmp, entry.Key);
                    resolutions.Add(tmp);
                }
            }
           
            
              
            //int currentPeriodLength;
            long currentTimestamp = 0;
            //string currentTicker;
            string stockDataParams;
            string googleFinaceBaseUrl = "http://www.google.com/finance/getprices?x=BVMF&f=d,c,v,o,h,l&df=cpct&auto=0&ei=Ef6XUYDfCqSTiAKEMg&p=100Y";
            string[] lines;
            string[] lineData;
            string resultData;           
            //Candle currentCandle;
           // List<Candle> currentCandleList;
            DateTime currentDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime candleDateTime;           
            //Dictionary<string, bool> updatesNeeded = new Dictionary<string, bool>();
            Dictionary<string, StringBuilder> updateQueries = new Dictionary<string, StringBuilder>();
            StringBuilder updateQuery;
            bool updateNeeded;

             totalData = tickers.Count * resolutions.Count;
             currentData = 0;
            bootstrap.MainLabel = "Obtendo dados históricos...";
            bootstrap.SubProgress = 0;
            foreach(string currentTicker in tickers)
            {
                foreach (int currentPeriodLength in resolutions)
                {

                    Stock currentStock = stockManager.Get(currentTicker);
                    currentStock.CreateHistoricalDataList(currentPeriodLength);
                    //currentStock.CreateHistoricalData()
                    //candleManager.CreateList(currentStock.Id, currentPeriodLength);
                                                         
                    resultData = "SELECT timestamp FROM period WHERE stock_id = ";
                    resultData += currentStock.Id + " AND periodLength = " + currentPeriodLength;
                    resultData += " ORDER BY timestamp DESC LIMIT 1";
                    updateNeeded = false;
                    results = DB.Select(resultData);


                    if (results[0].Count == 0)  //se o ultimo periodo do db for de um dia anterior a ontem, pegar do google e atualizar.
                        updateNeeded = true;
                    else
                    {
                        DateTime lastUpdateDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        lastUpdateDateTime = lastUpdateDateTime.AddSeconds(long.Parse(results[0][0]));
                       // bootstrap.Debug("NOW:" + DateTime.Now.ToString() + "\n", true);
                      //  bootstrap.Debug(lastUpdateDateTime.ToString() + "\n", true);
                     //   bootstrap.Debug((DateTime.Now - lastUpdateDateTime).TotalDays + "\n" + results[0][0] + "\n", true);
                        if ((DateTime.Now - lastUpdateDateTime).TotalDays >= 1)
                            updateNeeded = true;
                    }

                    
                    //updatesNeeded.Add(currentTicker + "_" +currentPeriodLength, updateNeeded);

                    int value = (int)((currentData / totalData) * 100);
                    value = value > 100 ? 100 : value;
                    value = value < 0 ? 0 : value;
                    bootstrap.SubProgress = value;
                    //bootstrap.Debug(value+"");
                    currentData++;
                    


                    historicalResolutionSource.TryGetValue(currentPeriodLength, out resultData);
                    if (!updateNeeded)
                    {
                       // bootstrap.Debug("No Update Nedded @@@@@@\n", true);
                        bootstrap.SubLabel = currentTicker + ":" + resultData + " de Base Local...";

                    }
                    else
                    {
                       // bootstrap.Debug("Updating...\n", true);

                        bootstrap.SubLabel = currentTicker + ":" + resultData + " de Google...";
                        //Clipboard.SetText(bootstrap.SubLabel);

                       

                        stockDataParams = "&q=" + currentTicker + "&i=" + currentPeriodLength;

                        HttpResponseMessage response = client.GetAsync(googleFinaceBaseUrl + stockDataParams).Result;  // Blocking call!
                        if (response.IsSuccessStatusCode)
                        {

                            resultData = response.Content.ReadAsStringAsync().Result;
                            resultData = resultData.Replace(",", "@");
                            resultData = resultData.Replace(".", ",");
                            lines = resultData.Split('\n');
                            //8 linhas de cabeçalho, no min
                            if (lines.Length > 7)
                            {



                                updateQuery = new StringBuilder();
                                updateQuery.Append("INSERT INTO period VALUES ");

                              

                                //resultData = "INSERT INTO period VALUES ";
                                // resultData = "";
                                for (int i = 7; i < lines.Length; i++)
                                {
                                    lineData = lines[i].Split('@');
                                    if (lineData.Length != 6)
                                        continue;
                                    //ignorar linhas q começam com a
                                    if (lineData[0].Contains("a")) //nova timestamp;
                                    {
                                        currentTimestamp = long.Parse(lineData[0].Replace("a", ""));
                                        //resultData += "Setando timestamp para: " + currentTimestamp + "\n";
                                        currentDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                                        currentDateTime = currentDateTime.AddSeconds(currentTimestamp).ToLocalTime();
                                        currentTimestamp = AppData.ConvertToUnixTime(currentDateTime);
                                        continue;
                                    }
                                    candleDateTime = currentDateTime.AddSeconds(currentPeriodLength * long.Parse(lineData[0]));
                                   
                                    updateQuery.Append(
                                           "(" +
                                           currentStock.Id + ";" +
                                           AppData.ConvertToUnixTime(candleDateTime) + ";" +
                                           currentPeriodLength + ";" +
                                           lineData[4] + ";" +
                                           lineData[1] + ";" +
                                           lineData[2] + ";" +
                                           lineData[3] + ";" +
                                           lineData[5] + ");"
                                    );
                                }

                                updateQueries.Add(currentTicker + "_" + currentPeriodLength,updateQuery); 
                            }
                            else
                            {
                                //Clipboard.SetText(googleFinaceBaseUrl + stockDataParams);
                                bootstrap.Debug("Resposta inválida\n" + resultData + "\n" + googleFinaceBaseUrl + stockDataParams + "\n");
                            }
                        }
                        else
                        {
                            bootstrap.Debug(response.RequestMessage.RequestUri + " : Faiô!: " + (int)response.StatusCode + " : " + response.ReasonPhrase);                           
                        }
                        


                    }

                }
            }
            totalData = updateQueries.Count;
            currentData = 0;

            //bootstrap.SubLabel = "Salvando novos dados obtidos...";
           
            foreach(KeyValuePair<string, StringBuilder> sb in updateQueries)
            {


               
                //int stockId;
                string periodLength;
                string ticker = sb.Key.Split('_')[0];
               // stockIdByTicker.TryGetValue(ticker, out stockId);
                historicalResolutionSource.TryGetValue(int.Parse(sb.Key.Split('_')[1]), out periodLength);

                bootstrap.SubLabel = "Atualizando dados históricos de " + ticker + ":" + periodLength + "...";

                string query = sb.Value.ToString();
                query = query.Replace(",", ".");
                query = query.Replace(";", ",");
                query += "@@@";
                query = query.Replace(",@@@", " ON DUPLICATE KEY UPDATE stock_id=stock_id");
                //Clipboard.SetText(query);
                try
                {
                    DB.Query(query);
                }
                catch (Exception) { }
                
                query = null;
                bootstrap.SubProgress = (int)((currentData / totalData) * 100);

            }
            updateQueries.Clear();


            //TODO: Adicionar dados RTD ao banco.
            //somente os dados que o google não possui, q geralmente são os de aftermarkert

            //recarregar tudo do db.

            totalData = stockManager.All.Count;
            currentData = 0;
            //string temp;
            
            foreach (Stock stock in stockManager.All)
            {                
                bootstrap.SubLabel = "Carregando dados históricos de " + stock.Name + "...";
                stock.HistoricalDataManager.ReloadAllFromDb();
                bootstrap.SubProgress = (int)((currentData / totalData) * 100);
                currentData++;
            }
     

            loadDone = true;
        }

        private static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }

        public static int HistoricalDataResolutionStringToSeconds(string resolution)
        {           
            char multiplier = resolution.Last();
            int size = int.Parse(resolution.Replace("" + multiplier, ""));
            switch(multiplier)
            {
                default: 
                case 'm': return size * 60; //minuto
                case 'h': return size * 3600; //hora
                case 'd': return size * 86400; //dia
            }
        }

    }
}
