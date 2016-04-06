using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    class Player
    {
        public double money = 5000;
        public Car car = new Car();

        public override string ToString()
        {
            return "Money: "+ money;
        }
    }
}
