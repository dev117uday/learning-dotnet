using System;

namespace IProgram1
{
    interface IDriveable
    {
        int Wheels { get; set; }
        double Speed { get; set; }
        void Move();
        void Stop();
    }
    class Car : IDriveable
    {
        public string Brand { get; set; }
        public Car(string brand = "no brand", int wheels = 2, double speed = 0)
        {
            Brand = brand;
            Wheels = wheels;
            Speed = speed;
        }
        public int Wheels { get; set; }
        public double Speed { get; set; }
        public void Move()
        {
            Console.WriteLine("moving");
        }
        public void Stop()
        {
            Console.WriteLine("stopping");
        }
    }
}