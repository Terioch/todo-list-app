using System;
using System.Collections;
using System.Linq;

namespace TodoListApp.Examples
{    
    class ExampleList<T>
    {
        private readonly T[] _items;
        private int _size;       

        public ExampleList()
        {
            _items = new T[100];
        }

        public ExampleList(int capacity)
        {
            if (capacity <= 0)
            {
                _items = new T[100];
            } 
            else
            {
                _items = new T[capacity];
            }
        }

        public void Add(T item)
        {           
            _items[_size] = item;
            _size++;           
        }                   
    }

    class Car
    {
        public string Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FuelType { get; set; }
    }

    class ExampleListImplementation
    {
        void ExampleMain()
        {            
            ExampleList<int> list = new ExampleList<int>(20);
            ExampleList<string> list2 = new ExampleList<string>();
            list.Add(5);
            Car[] cars = GetArray<Car>(20);
        }

        T[] GetArray<T>(int capacity)
        {
            return new T[capacity];
        }        
    }
}
