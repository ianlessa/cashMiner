using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIns;

namespace DataProviders
{
    public interface iDataProvider<DataType> : iPlugin
    {

        List<DataType> GetAllFrom(int dataId, int resolution);
        List<DataType> GetAllFrom(string dataId, int resolution);
        List<DataType> GetAllFrom(string database, string dataId, int resolution);
        List<DataType> GetAllFrom(string database, string dataId, int resolution, string maxPeriods);

        bool Authenticate(String username, String password);


        string Username { get; set; }
        string Password { get; set; }


    }
}

