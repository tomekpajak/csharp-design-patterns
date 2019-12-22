using System;

namespace tp.FactoryMethod
{
    enum HPLaptopModel { envy, pavilion };
    interface ILaptop
    {
        string Description { get; }
    }
    class EnvyLaptop : ILaptop
    {
        public string Description => "HPEnvy Laptop";
    }
    class PavilionLaptop : ILaptop
    {
        public string Description => "Pavilion Laptop";
    }

    namespace CaseInterface
    {
        interface IHPLaptopFactory
        {
            ILaptop CreateHPLaptop();
        }
        class PavilionHPLaptopFactory : IHPLaptopFactory
        {
            public ILaptop CreateHPLaptop() => new PavilionLaptop();
        }
        class EnvyHPLaptopFactory : IHPLaptopFactory
        {
            public ILaptop CreateHPLaptop() => new EnvyLaptop();
        }
    }

    namespace CaseAbstractClass
    {
        abstract class HPLaptopFactory
        {
            public ILaptop MakeLaptop()
            {
                ILaptop laptop = CreateLaptop();
                return laptop;
            }

            protected abstract ILaptop CreateLaptop();
        }
        class PavilionHPLaptopFactory : HPLaptopFactory
        {
            protected override ILaptop CreateLaptop() => new PavilionLaptop();
        }
        class EnvyHPLaptopFactory : HPLaptopFactory
        {
            protected override ILaptop CreateLaptop() => new EnvyLaptop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILaptop laptop = null;

            CaseInterface.IHPLaptopFactory interfaceFactory = null;
            interfaceFactory = new CaseInterface.EnvyHPLaptopFactory();
            laptop = interfaceFactory.CreateHPLaptop();
            Console.WriteLine(laptop.Description);

            CaseAbstractClass.HPLaptopFactory abstractFactory = null;
            abstractFactory = new CaseAbstractClass.PavilionHPLaptopFactory();
            laptop = abstractFactory.MakeLaptop();
            Console.WriteLine(laptop.Description);
        }
    }
}
