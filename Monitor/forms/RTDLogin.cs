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
using System.Configuration;

namespace Monitor
{
    public partial class RTDLogin : Form
    {

        private AppData app;
       // private MainForm mainForm;        

        public RTDLogin(AppData app)
        {
            this.app = app;
            InitializeComponent();
        }

        private void RTDUser_Load(object sender, EventArgs e)
        {
            this.RTDUser_text.Text = ConfigurationManager.AppSettings["RTDDefaultUser"];
        }

        private void RTDConnect_bt_Click(object sender, EventArgs e)
        {


            RTDConnect_bt.Enabled = false;
            RTDStatus_label.Text = "Por favor, aguarde...";
            RTDConnect_bt.Text = "Conectando...";


            switch (app.streamerClient.AuthAttepmpt(RTDUser_text.Text))
            {               
                case RTDStream.StreamerClient.AuthStatus.EmptyData:
                    RTDStatus_label.Text = "Usuário inválido: 1";
                break;
                case RTDStream.StreamerClient.AuthStatus.InvalidData:
                    RTDStatus_label.Text = "Usuário inválido: 2";
                break;
                case RTDStream.StreamerClient.AuthStatus.Exception:
                    RTDStatus_label.Text = "Usuário inválido: 3";
                break;


                case RTDStream.StreamerClient.AuthStatus.Success:

                   /* if (mainForm == null)
                    {
                        mainForm = new MainForm(app);
                    }*/

                    this.Hide();
                    //mainForm.Show();
                    RTDConnect_bt.Text = "Conectar";
                    RTDStatus_label.Text = "Desconectado.";

                    break;
            }              
            RTDConnect_bt.Enabled = true;
            RTDConnect_bt.Text = "Conectar";
        }                
    }
}
