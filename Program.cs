using Abstraction.src;

namespace Abstraction
{
    public class Program
    {
        static void Main(string[] args)
        {
             Animal myDog = new Dog { Name = "Buddy" }; 
            
            Singleton singleton1 = Singleton.Instance;

            SingletonThree singletonThree = SingletonThree.Instance;
        }
    }


    public interface IFlyable
    {
        void Fly();
    }

    public interface ISwimmable
    {
        void Swim();
    }   
    public interface IVehicle
    {
        
        void StartEngine();
    }
    public abstract class Animal : IFlyable
    {
        public   delegate int Age();
        public  string Name { get; set; }
        public Animal()
        {            
        }
        public abstract void Speak();
        public abstract void Eat();
        public abstract void Sleep();
        public abstract void Move();
        public virtual void Fly()
        {
        }
    }

    public class Parrot : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Parrot Eats");
        }
        public override void Move()
        {
            Console.WriteLine("Parrot Move");
        }
        public override void Sleep()
        {
            Console.WriteLine("Parrot sleeps");
        }
        public override void Speak()
        {
            Console.WriteLine("Parrot Speaks");
        }
    }
    public class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Dog Eats");
        }

        public override void Move()
        {
            Console.WriteLine("Dog Move");
        }

        public override void Sleep()
        {
            Console.WriteLine("Dog sleeps");
        }

        public override void Speak()
        {
            Console.WriteLine("Dog Speaks");
        }
    }
}
