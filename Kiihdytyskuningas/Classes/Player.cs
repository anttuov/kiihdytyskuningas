using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Kiihdytyskuningas
{

    public class Player
    {
        public double money = 5000;

        private Car car = new Car();

        public Car Car
        {
            get
            {
                return car;
            }
            set
            {

            }
        }


        public void InstallPart(object part)
        {
            Type type = part.GetType();
            Debug.WriteLine(type);

            if (type == typeof(Wheel))
            {
                car.SetWheel((Wheel)part);
            }
            else if (type == typeof(Motor))
            {
                car.SetMotor((Motor)part);
            }
            else if (type == typeof(Gearbox))
            {
                car.SetGearbox((Gearbox)part);
            }
            else if (type == typeof(Car))
            {
                car = (Car)(part);
            }

        }



        public override string ToString()
        {
            return "Money: "+ money + "€\n" + car.ToString();
        }
    }
}
