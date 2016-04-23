using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public class Gearbox : Part
    {

        public int gears;
        public override string ToString()
        {
            if (name != null)
            {
                return name + ". Gears:" + gears;
            }
            else
            {
                return "does not exist";
            }
        }

    }
}
