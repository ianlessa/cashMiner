using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Monitor.RTDStream
{
    public class StreamerClient
    {
        private const string origin = "secret";
        private const string host = "secret";
        private const int port = 5801;

        private IRtdStreamerListener listener;
        private List<string> items;

        private string user_name;
        private string data_quality;
        private string expiration_date;
        private string auth_token;
        public enum AuthStatus { Success, InvalidData, EmptyData, Exception }
        //private bool isAuth;

        public List<string> Items {
            get {
                return this.items;
            }
       }



        public StreamerClient(IRtdStreamerListener listener, List<string> items)
        {
            //this.isAuth = false;
            this.listener = listener;
            this.items = new List<string>((IEnumerable<string>)items);

        }

        private void setCredentials(string userName, string dataQuality, string expirationDate, string authToken)
        {
            user_name = userName;
            data_quality = dataQuality;
            expiration_date = expirationDate;
            auth_token = authToken;
        }

        public StreamerClient.AuthStatus AuthAttepmpt(string username) 
        {

            try
            {
                string str1 = "secret";
                WebClient webClient = new WebClient();
                webClient.Headers.Add("X-RTD-USER", username);
                webClient.Headers.Add("X-RTD-PASS", username);
                string address = str1;
                string str2 = webClient.DownloadString(address);

                string userName;
                string dataQuality;
                string authToken;
                string expirationDate;
                string quotesbvsp;

                if (str2 != "")
                {
                    string[] strArray = str2.Split('|');
                    if (strArray.Length == 5 && strArray[0] != null && (strArray[1] != null && strArray[2] != null) && (strArray[3] != null && strArray[4] != null))
                    {
                        userName = strArray[0];
                        dataQuality = strArray[1];
                        authToken = strArray[2];
                        expirationDate = strArray[3];
                        quotesbvsp = strArray[4];
                        if (username.ToLower().Equals(userName.ToLower()))
                        {
                            //isAuth = true;
                            this.setCredentials(userName, dataQuality, expirationDate, authToken);
                            //streamerClient.start();
                        }

                    }
                    else
                    {
                        return StreamerClient.AuthStatus.InvalidData;
                    }
                }
                else
                {
                    return StreamerClient.AuthStatus.EmptyData;
                }

                //isAuth = true;
                return StreamerClient.AuthStatus.Success;
            }catch(Exception)
            {
                return StreamerClient.AuthStatus.Exception;
            }
        }
    }
}
