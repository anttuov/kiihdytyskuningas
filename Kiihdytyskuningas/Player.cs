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
        private Car car = new Car();

        public void SetMotor(Motor motor)
        {
            car.motor = motor;
        }

        public void SetWheel(Wheel wheel)
        {
            car.wheel = wheel;
        }

        public void SetGearbox(Gearbox gearbox)
        {
            car.gearbox = gearbox;
        }

        public override string ToString()
        {
            return "Money: "+ money + "\nCar: " + car.ToString() + "\n  Motor: " + car.motor.ToString() + "\n  Wheels: " + car.wheel.ToString() + "\n  Gearbox: "+ car.gearbox.ToString();
        }
    }
}
