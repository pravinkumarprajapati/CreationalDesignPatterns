using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.src
{
    public interface IComputerBuilder
    {
        void SetCPU(string cpu);
        void SetRAM(string ram);
        void SetMotherboard(string storage);
        void SetGraphicsCard(string storage);
        Computer GetComputer();
    }

    public class Computer
    {
        public string Storage { get; set; }
        public string CPU { get; set; }
        public string Motherboard { get; set; }
        public string GraphicsCard { get; set; }
        public int RAM { get; set; }


        public string DisplayConfiguration()
        {
            return $"Computer [CPU={CPU}, RAM={RAM}, Storage={Storage}]";
        }
    }

    public class HomeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();
        public void SetCPU(string cpu)
        {
            _computer.CPU = cpu;
        }
        public void SetRAM(string ram)
        {
            _computer.RAM = int.Parse(ram);
        }
        public void SetMotherboard(string motherboard)
        {
            _computer.Motherboard = motherboard;
        }
        public void SetGraphicsCard(string graphicsCard)
        {
            _computer.GraphicsCard = graphicsCard;
        }
        public Computer GetComputer()
        {
            return _computer;
        }
    }


    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();
        public void SetCPU(string cpu)
        {
            _computer.CPU = cpu;
        }
        public void SetRAM(string ram)
        {
            _computer.RAM = int.Parse(ram);
        }
        public void SetMotherboard(string motherboard)
        {
            _computer.Motherboard = motherboard;
        }
        public void SetGraphicsCard(string graphicsCard)
        {
            _computer.GraphicsCard = graphicsCard;
        }
        public Computer GetComputer()
        {
            return _computer;
        }
    }

    public class ComputerDirector
    {
        private readonly IComputerBuilder _builder;
        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }
        public Computer Construct()
        {
            _builder.SetCPU("Intel i7");
            _builder.SetRAM("16");
            _builder.SetMotherboard("ASUS ROG STRIX Z490-E");
            _builder.SetGraphicsCard("NVIDIA GeForce RTX 3080");
            return _builder.GetComputer();
        }
    }

    public class Client
    {
        public void Main()
        {
            IComputerBuilder homeBuilder = new HomeComputerBuilder();
            ComputerDirector homeDirector = new ComputerDirector(homeBuilder);
            Computer homeComputer = homeDirector.Construct();
            Console.WriteLine("Home Computer Configuration: " + homeComputer.DisplayConfiguration());
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            ComputerDirector gamingDirector = new ComputerDirector(gamingBuilder);
            Computer gamingComputer = gamingDirector.Construct();
            Console.WriteLine("Gaming Computer Configuration: " + gamingComputer.DisplayConfiguration());
        }
    }
}
