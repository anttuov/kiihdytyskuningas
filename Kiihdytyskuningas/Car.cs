using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public class Car : Part
    {

        public int weight;
        public string img;

        public Gearbox gearbox = new Gearbox();
        public Motor motor = new Motor();
        public Wheel wheel = new Wheel();


    }
}
