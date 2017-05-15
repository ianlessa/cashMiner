using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIns;

namespace Strategy
{
    public interface iStrategy : iPlugin 
    {
        /*
        bool Load();
        string Name { get; }
        string Identifier { get; }        
        bool Active { get; set; }
        */
        bool run();

    }
}
