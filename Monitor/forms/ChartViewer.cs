using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Reflection;
using System.IO;
using Stocks;
using Newtonsoft.Json;

namespace Monitor
{
    public partial class ChartViewer : Form
    {
        
        public ChromiumWebBrowser chromeBrowser;

       /* private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                return File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;
            }

            return null;
        }*/

        private AppData app;
        private Stock stock;
        private int resolution;               

        public int Resolution
        {
            get
            {
                return resolution;
            }
            set
            {
                resolution = value;
            }
        }
        public Stock Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
            }
        }



        public string GetStock()
        {
            return JsonConvert.SerializeObject(stock);           
        }
        public string GetCandleList()
        {
            if (resolution == null)
                resolution = 3600;

            return JsonConvert.SerializeObject(stock.HistoricalData(resolution));
        }


        public ChartViewer(AppData app)
        {
            this.app = app;
            InitializeComponent();
            InitializeChromium();
        }




        private void InitializeChromium()
        {

            //AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            
            //ChromiumWebBrowser//.LoadString(chartViewBase, "chartViewer/chartViewerMain.html");
           

            chromeBrowser = new ChromiumWebBrowser(string.Empty)
            {
                Location = new Point(0, 0),
                Dock = DockStyle.Fill
            };

            
            
            string[] completePath = Assembly.GetEntryAssembly().Location.Split('\\');
            completePath[completePath.Length-1] = "";      

             if (File.Exists("chartViewer/chartViewerMain.html")) {
                 string chartViewBase = File.ReadAllText("chartViewer/chartViewerMain.html");
                 chromeBrowser.LoadHtml(chartViewBase, String.Join("\\",completePath)+ "chartViewer/chartViewerMain.html");
             }          


            this.Controls.Add(chromeBrowser);
            chromeBrowser.RegisterAsyncJsObject("chartViewer",this);

            //chromeBrowser.RegisterAsyncJsObject("chartViewer", this);
            
        }
        

        public void OpenDevTools()
        {
            chromeBrowser.ShowDevTools();
        }




        //ver se esses são necessários.
        private void ChartViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ChartViewer_Shown(object sender, EventArgs e)
        {
            

        }
    }
}
