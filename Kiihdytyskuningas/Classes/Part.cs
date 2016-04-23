using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public abstract class Part
    {
        public string name;
        public double price;
        public override string ToString()
        {
            if (name != null)
            {
                return name;
            }
            else
            {
                return "does not exist";
            }
        }
    }
}
