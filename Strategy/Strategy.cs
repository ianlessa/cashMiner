using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIns;

namespace Strategy
{

    public abstract class Strategy : Plugin, iStrategy
    {
        public Strategy(string name, string identifier) : base(name, identifier)
        {}

        /*
        protected bool active;       
        protected string name;
        protected string identifier;

        public Strategy()
        {
            active = false;            
        }
        
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Identifier
        {
            get
            {
                return identifier;
            }
        }
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        */
        public abstract bool run();
    }
}
