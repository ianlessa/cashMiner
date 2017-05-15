using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//using RTDStream;

namespace Monitor
{
    
    static class Program
    {

      

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                     

            AppData app = new AppData();
            //app.bootstrap = new BootstrapForm(app);
            app.Load();
                    
            Application.Run(app.mainForm);


        }
    }
}
