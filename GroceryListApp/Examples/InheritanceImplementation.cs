using System;

namespace TodoListApp.Examples
{
    class InheritanceImplementation
    {
        class Car : Vehicle
        {
            public string FuelType { get; set; }
            public double AmountOfFuel { get; set; }
        }

        class Bicycle : Vehicle
        {

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
