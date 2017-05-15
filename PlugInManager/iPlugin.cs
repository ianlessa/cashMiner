using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIns
{
    public interface iPlugin
    {        
        string Name { get; }
        string Identifier { get; }
        bool Active { get; set; }
    }
}
