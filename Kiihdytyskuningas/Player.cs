using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiihdytyskuningas
{
    public class Player
    {
        public double money = 5000;
        public Car car = new Car();

        public override string ToString()
        {
            return "Money: "+ money + "\nCar: " + car.ToString() + "\n  Motor: " + car.motor.ToString() + "\n  Wheels: " + car.wheel.ToString() + "\n  Gearbox: "+ car.gearbox.ToString();
        }
    }
}
