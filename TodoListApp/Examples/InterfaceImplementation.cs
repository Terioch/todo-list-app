using System;

namespace TodoListApp.Examples
{
    public class InterfaceImplementation
    {
        class Car : IVehicle
        {
            public double MaxSpeed { get; set; }
            public string Model { get; set; }
            public string FuelType { get; set; }
            public double AmountOfFuel { get; set; }

            public void Move()
            {
                Console.WriteLine("Turn on ignition");
                Console.WriteLine("Press down on accelerator pedal");
            }

            public void Turn()
            {
                Console.WriteLine("Switch on indicator");
                Console.WriteLine("Rotate steering wheel");
            }

            public void Stop()
            {
                Console.WriteLine("Press down on break pedal");
            }
        }

        class Bicycle : IVehicle, ISecondVehicle
        {
            public double MaxSpeed { get; set; }
            public string Model { get; set; }

            public void Move()
            {
                Console.WriteLine("Press down on pedals");
            }

            public void Stop()
            {
                Console.WriteLine("Press down hands over breaks");
            }

            public void Turn()
            {
                Console.WriteLine("Rotate handlebars");
            }
        }

        static void ExampleMain()
        {
            Car car = new Car();
            car.Model = "Nissan Leaf";
            car.FuelType = "Electric";
            car.Move();
            car.Turn();
            car.Stop();

            Bicycle bicycle = new Bicycle();
            bicycle.Model = "Mountain Bike";
            bicycle.Move();
            bicycle.Turn();
            bicycle.Stop();
        }
    }
}
