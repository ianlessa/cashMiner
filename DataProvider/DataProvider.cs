using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIns;

namespace DataProviders
{

    
    public abstract class DataProvider<DataType> : Plugin, iDataProvider<DataType>
    {
        protected bool authenticated;
           
        protected string username;
        protected string password;

        public DataProvider(string name, string identifier) : base(name, identifier)
        { }

        public bool Authenticated
        {
            get
            {
                return authenticated;
            }
            set
            {
                authenticated = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
     

        public abstract List<DataType> GetAllFrom(int dataId, int resolution);
        public abstract List<DataType> GetAllFrom(string dataId, int resolution);
        public abstract List<DataType> GetAllFrom(string database, string dataId, int resolution);
        public abstract List<DataType> GetAllFrom(string database, string dataId, int resolution, string maxPeriods);
        public abstract bool Authenticate(string username, string password);      


    }
}
