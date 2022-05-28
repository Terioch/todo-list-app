using System;

namespace TodoListApp.Examples
{
    class Vehicle
    {
        public double MaxSpeed { get; set; }
        public string Model { get; set; }

        public void Move()
        {
            Console.WriteLine("Drive");
        }

        public void Turn()
        {
            Console.WriteLine("Switch on indicator");
            Console.WriteLine("Rotate steering wheel");
        }

        public void Stop()
        {            
            Console.WriteLine("Press break pedal");
        }
    }    
}
