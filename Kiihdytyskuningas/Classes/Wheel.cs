using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public class Wheel : Part
    {

        public int weight;
        public int traction;

        public override string ToString()
        {
            if (name != null)
            {
                return name + ". Traction: " + traction + ". Weight: " + weight;
            }
            else
            {
                return "does not exist";
            }
        }

    }

}
