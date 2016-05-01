using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Kiihdytyskuningas
{

    public class Car : Part
    {

        public int weight;
        public string img;

        private Gearbox gearbox = new Gearbox();
        private Motor motor = new Motor();
        private Wheel wheel = new Wheel();

        public Gearbox Gearbox
        {
            get
            {
                return gearbox;
            }
            set
            {

            }
        }
        //very mathematic function for speed calculations
        public double PowerFunction()
        {
            double power = ((motor.power / 300.0) * (wheel.traction / 100.0)) / ((weight+motor.weight+wheel.weight)/1000.0);
            return power;
        }

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

        public override string ToString()
        {

            if (name == null) name = "No car!";
            return "Car: "+name+". Weight: "+weight+"\n-Motor: " + motor.ToString() + "\n-Wheels: " + wheel.ToString() + "\n-Gearbox: " + gearbox.ToString();
        }
        




    }
}
