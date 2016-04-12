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

        public void SetMotor(Motor _motor)
        {
            motor = _motor;
        }

        public void SetWheel(Wheel _wheel)
        {
            wheel = _wheel;
        }

        public void SetGearbox(Gearbox _gearbox)
        {
            gearbox = _gearbox;
        }

        public Gearbox gearbox = new Gearbox();
        public Motor motor = new Motor();
        public Wheel wheel = new Wheel();


    }
}
