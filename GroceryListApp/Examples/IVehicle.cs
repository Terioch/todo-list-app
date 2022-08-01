using System;

namespace TodoListApp.Examples
{    
    interface IVehicle
    {
        double MaxSpeed { get; set; }
        string Model { get; set; }
        void Move();             
        void Turn();
        void Stop();
    }

    interface ISecondVehicle
    {

    }
}
