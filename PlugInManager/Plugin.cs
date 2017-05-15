using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugIns
{
    public abstract class Plugin : iPlugin
    {
        protected bool active;
        protected string filename;
        protected string name;
        protected string identifier;

        public Plugin(string name, string identifier)
        {
            active = false;           
            this.name = name;
            this.identifier = identifier;
        }

        public bool Load()
        {

            return true;
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
    }

}
