using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Monitor
{
    public partial class BootstrapForm : Form
    {

        private AppData app;

        public BootstrapForm(AppData app)
        {
            this.app = app;
            InitializeComponent();
          
        }

        private void BootstrapForm_Shown(object sender, EventArgs e)
        {

            //app.Load();
            /*app.rtdLogin = new RTDLogin(app);
            app.rtdLogin.Show();
            this.Hide();*/
        }

        public string MainLabel
        {
            get
            {
                return mainLabel.Text;
            }
            set
            {
                mainLabel.Text = value;
                mainLabel.Invalidate();
                mainLabel.Update();
                mainLabel.Refresh();
                Application.DoEvents();
            }
        }
        public string SubLabel
        {
            get
            {
                return subLabel.Text;
            }
            set
            {
                subLabel.Text = value;
                subLabel.Invalidate();
                subLabel.Update();
                subLabel.Refresh();
                Application.DoEvents();
            }
        }
        public int MainProgress
        {
            get
            {
                return mainProgress.Value;
            }
            set
            {
                mainProgress.Value = value;
               /* mainProgress.Invalidate();
                mainProgress.Update();
                mainProgress.Refresh();
                Application.DoEvents();*/
            }
        }
        public int SubProgress
        {
            get
            {
                return subProgress.Value;
            }
            set
            {
                subProgress.Value = value < 0 ? 0 : value;
                subProgress.Invalidate();
                subProgress.Update();
                subProgress.Refresh();
                Application.DoEvents();
            }
        }
        public int SubProgressMax 
        {
            get
            {
                return subProgress.Maximum;
            }
            set
            {
                subProgress.Maximum = value;
            }
            
        }




        public void Debug(string msg)
        {
            Bootstrap_debug_output.Text = msg;
        }

        public void Debug(string msg, bool append)
        {
            if(!append)
            {
                Debug(msg);
            }
            else
            {
                Bootstrap_debug_output.Text += msg;
            }
        }

    }
}
