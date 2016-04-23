using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public class Motor : Part
    {

        public int power;
        public int weight;

        public override string ToString()
        {
            if (name != null)
            {
                return name + ". Power:" + power + ". Weight: " + weight;
            }
            else
            {
                return "does not exist";
            }
        }
    }


}
