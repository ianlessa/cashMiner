using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Strategy;
using Stocks;
using Candles;
using System.Text.RegularExpressions;
using DataProviders;
using CefSharp;


namespace Monitor
{
    public partial class MainForm : Form
    {
        private AppData app;
        private List<string> strategyIndentifiers;
        private int selectedStrategy;
        private DataTable stockDetailHistoricalInfo;
        private Dictionary<int,Image> logos;        
       
        public MainForm(AppData app)
        {
            this.app = app;            
            InitializeComponent();

            logos = new Dictionary<int, Image>();


            this.MainConfig_RTDDefaultUser_text.Text = ConfigurationManager.AppSettings["RTDDefaultUser"];

            MainStockTab_StockList_listbox.Items.Clear();
            foreach (string item in app.streamerClient.Items)
            {
                MainStockTab_StockList_listbox.Items.Add(item);
            }

         /*   bool RTDStreamAutostart = false;
            if (ConfigurationManager.AppSettings["RTDStreamAutostart"].Equals("1"))
                RTDStreamAutostart = true;
                */
            //RTDStreamAutostart_cb.Checked = RTDStreamAutostart;
            
            MainStartegyCheckList_treeView.Nodes.Clear();
            strategyIndentifiers = new List<string>();
            int currentSize = 0;
            foreach (iStrategy strategy in app.strategyManager.All)
            {
               
                MainStartegyCheckList_treeView.Nodes.Add(strategy.Name);
                strategyIndentifiers.Add(strategy.Identifier);
                MainStartegyCheckList_treeView.Nodes[currentSize].Checked = strategy.Active;
               
                currentSize++;
            }

            StrategyDetails_gb.Hide();
            MainStockDetail_gb.Hide();


            //sobre dados históricos.
            string defaultHDPIdentifier = "";
            if (app.historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"] != null)
            {
                defaultHDPIdentifier = app.historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"].Value;
            }
            foreach (HistoricalDataProvider hdp in app.historicalDataManager.All)
            {
                if (defaultHDPIdentifier.Equals(hdp.Identifier))
                {
                    HDDefaultProvider_cb.SelectedIndex = HDDefaultProvider_cb.Items.Add(hdp.Name);
                }
                else
                {
                    HDDefaultProvider_cb.Items.Add(hdp.Name);
                }
            }

            HistoricalDataAutoUpdate_check.Checked =
                app.historicalDataManager.Config.AppSettings.Settings["historicalDataAutoUpdate"] != null && 
                app.historicalDataManager.Config.AppSettings.Settings["historicalDataAutoUpdate"].Value == "1" ? true : false;
                        
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
            app.rtdLogin.Close();
        }

        private void RTDDisconect_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
            app.rtdLogin.Show();
        }

        private void MainConfig_RTDDefaultUser_text_TextChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["RTDDefaultUser"].Value = MainConfig_RTDDefaultUser_text.Text;
            config.Save(ConfigurationSaveMode.Modified);
        }

       /* private void RTDStreamAutostart_cb_CheckedChanged(object sender, EventArgs e)
        {
            string autoStart = "0";
            if (RTDStreamAutostart_cb.Checked)
                autoStart = "1";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["RTDStreamAutostart"].Value = autoStart;
            config.Save(ConfigurationSaveMode.Modified);
        }*/

        private void StrategyReload_bt_Click(object sender, EventArgs e)
        {

            app.strategyManager.Load();
            MainStartegyCheckList_treeView.Nodes.Clear();
            strategyIndentifiers.Clear();
            int currentSize = 0;
            foreach (iStrategy strategy in app.strategyManager.All)
            {

                MainStartegyCheckList_treeView.Nodes.Add(strategy.Name);
                strategyIndentifiers.Add(strategy.Identifier);
                MainStartegyCheckList_treeView.Nodes[currentSize].Checked = strategy.Active;

                currentSize++;
            }

        }


        private void MainStartegyCheckList_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            int i = e.Node.Index;
            
            iStrategy strategy = app.strategyManager.Get(strategyIndentifiers[i]);
            if (strategy != null)
            {
                StrategyDetail_name_lb.Text = strategy.Name;
                StrategyDetail_identifier_lb.Text = strategy.Identifier;
                StrategyDetails_gb.Text = "Detalhes de " + strategy.Name;
                selectedStrategy = i;
                StrategyDetail_active_check.Checked = e.Node.Checked;
                StrategyDetails_gb.Show();
                return;
            }
            

            StrategyDetail_name_lb.Text = "";
            StrategyDetail_identifier_lb.Text = "";
            StrategyDetails_gb.Hide();
            selectedStrategy = -1;

        }

        private void MainStartegyCheckList_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            app.strategyManager.SetState(
              strategyIndentifiers[e.Node.Index],
              e.Node.Checked
            );

            if (e.Node.Index == selectedStrategy)
            {
                StrategyDetail_active_check.Checked = e.Node.Checked;
            }
        }

        private void StrategyDetail_active_check_Click(object sender, EventArgs e)
        {
            MainStartegyCheckList_treeView.Nodes[selectedStrategy].Checked = StrategyDetail_active_check.Checked;
        }

        private void MainStockTab_StockList_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            stockDetailHistoricalInfo = null;
            stockDetailHistoricalInfo = new DataTable();
            stockDetailHistoricalInfo.Columns.Add(new DataColumn("Resolução"));
            stockDetailHistoricalInfo.Columns.Add(new DataColumn("Início"));
            stockDetailHistoricalInfo.Columns.Add(new DataColumn("Fim"));
            stockDetailHistoricalInfo.Columns.Add(new DataColumn("N. Períodos"));
            MainStockDetail_historicalData_dg.Height = MainStockDetail_historicalData_dg.RowTemplate.Height;

            Stock stock = app.stockManager.Get(MainStockTab_StockList_listbox.SelectedItem.ToString());
            MainStockDetail_name_lb.Text = stock.Name;
            MainStockDetail_ticker_lb.Text = stock.Ticker;



            Image tmpImage;

            logos.TryGetValue(stock.Id, out tmpImage);
            if(tmpImage == null)
            {
                tmpImage = Image.FromFile(app.config.AppSettings.Settings["logoDir"].Value + "/" + Regex.Replace(stock.Ticker, "[0-9]", "") + ".png");
                logos.Add(stock.Id, tmpImage);
            }

            MainStockDetailLogo_pb.Image = tmpImage;

            foreach (KeyValuePair<string,bool> resolution in app.historicalDataResolutions)
            {
                
                List<Candle> candleList = stock.HistoricalData(AppData.HistoricalDataResolutionStringToSeconds(resolution.Key));
                DateTime temp;
                            
                string start = "Não disponível";
                string end  = "Não disponível";
                int dataSize = 0;

                if(candleList != null)
                {


                    temp = new DateTime(1970, 1, 1, 0, 0, 0);
                    start = temp.AddSeconds(candleList[0].Timestamp).ToString();
                    end = temp.AddSeconds(candleList.Last().Timestamp).ToString();

                    dataSize = candleList.Count;
                    //start = candleList[0].Timestamp.ToString();
                    //end = candleList.Last().Timestamp.ToString();
                }
                
                             
                stockDetailHistoricalInfo.Rows.Add(new Object[] { resolution.Key,start, end, dataSize});
                MainStockDetail_historicalData_dg.Height += MainStockDetail_historicalData_dg.RowTemplate.Height;
            }            
            MainStockDetail_historicalData_dg.DataSource = stockDetailHistoricalInfo;

            MainStockDetail_gb.Show();

        }

        private void RTDStreamStart_bt_Click(object sender, EventArgs e)
        {
            //if (!app.isStreaming)
                app.rtdLogin.Show();

            /*
            app.isStreaming = !app.isStreaming;

            if (app.isStreaming)
            {
                RTDStreamStart_bt.Text = "Interromper Streaming.";
            }
            else
            {
                RTDStreamStart_bt.Text = "Iniciar Streaming.";
            }
            */
        }
               

        private void HDDefaultProvider_cb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string identifier = app.historicalDataManager.Get(HDDefaultProvider_cb.SelectedIndex).Identifier;
            string oldIdentifier = app.historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"].Value;

            if (identifier.Equals(oldIdentifier) == false) {
                //ta lançando exceção na hora de salvar.

                app.historicalDataManager.Config.AppSettings.Settings["historicalDataProvider"].Value = identifier;
                app.historicalDataManager.Config.Save(ConfigurationSaveMode.Modified);
            }




        }

        private void HistoricalDataAutoUpdate_check_CheckedChanged(object sender, EventArgs e)
        {
            
            app.historicalDataManager.Config.AppSettings.Settings["historicalDataAutoUpdate"].Value = 
                HistoricalDataAutoUpdate_check.Checked  ? "1" : "0";

            app.historicalDataManager.Config.Save(ConfigurationSaveMode.Modified);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChartViewer chartViewer = new ChartViewer(app);

            chartViewer.Resolution = 15 * 60;
            string resolutionSource;
            app.historicalResolutionSource.TryGetValue(chartViewer.Resolution, out resolutionSource);
            
            chartViewer.Stock = app.stockManager.Get(MainStockTab_StockList_listbox.SelectedItem.ToString());

            chartViewer.Text = chartViewer.Stock.Ticker + ":" + resolutionSource;

            chartViewer.Show();
        }
    }
}
