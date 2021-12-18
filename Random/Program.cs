using System;

namespace Random
{
    class Program
    {
        static void Main(string[] args)
        {

            CarFactory factory = new CarFactory();
            ICar car = factory.CreateCar("Audi");
            car.Run();


            IAnimal[] animals = { new Dog(), new Cat(), new Dog(), new Cat(), new Dog(), new Cat() };
            AnimalComposite animalComposite = new AnimalComposite(animals);
            animalComposite.Run();

            var ss = Singleton.Instance;
            ss.PublicFunc();
            Console.ReadKey();

        }
    }
    public class Singleton
    {
        private static Singleton instance;
        private Singleton()
        {
        }
        public void PublicFunc()
        {
        }
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
    public interface IAnimal
    {
        void Run();
    }
    public class Dog : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Dog is running");
        }
    }
    public class Cat : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Cat is running");
        }
    }
    public class AnimalComposite : IAnimal
    {
        private IAnimal[] animals;

        public AnimalComposite(IAnimal[] animals)
        {
            this.animals = animals;
        }

        public void Run()
        {
            foreach (var animal in animals)
            {
                animal.Run();
            }
        }
    }
    public interface ICar
    {
        void Run();
    }
    public class BMW : ICar
    {
        public void Run()
        {
            Console.WriteLine("BMW is running");
        }
    }
    public class Audi : ICar
    {
        public void Run()
        {
            Console.WriteLine("Audi is running");
        }
    }
    public class CarFactory
    {
        public ICar CreateCar(string carType)
        {
            switch (carType)
            {
                case "BMW":
                    return new BMW();
                case "Audi":
                    return new Audi();
                default:
                    throw new Exception("Car type is not supported");
            }
        }
    }
    public class Car
    {
        private ICar _car;
        public Car(ICar car)
        {
            _car = car;
        }
        public void Run()
        {
            _car.Run();
        }
    }
}
