using System;
using System.Threading.Tasks;

namespace tp.FactoryMethod
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ILaptop laptop = null;

            Console.WriteLine("1. Factory method - using interface...");
            CaseInterface.IHPLaptopFactory interfaceFactory = null;
            interfaceFactory = new CaseInterface.EnvyHPLaptopFactory();
            laptop = interfaceFactory.CreateHPLaptop();
            Console.WriteLine(laptop.Description);

            Console.WriteLine("2. Factory method - using abstract class...");
            CaseAbstractClass.HPLaptopFactory abstractFactory = null;
            abstractFactory = new CaseAbstractClass.PavilionHPLaptopFactory();
            laptop = abstractFactory.MakeLaptop();
            Console.WriteLine(laptop.Description);

            Console.WriteLine("3. Factory method - using private constructor...");
            var laptop2 = LaptopPrivateConstructor.NewEnvyLaptop("2GH", 1);

            Console.WriteLine("4. Factory method - using asynchronous...");
            LaptopAsynchronous laptop3 = await LaptopAsynchronous.NewEnvyLaptopAsync("2GH", 1);

            Console.WriteLine("5. Factory method - using inner class...");
            var laptop4 = LaptopInnerClass.Factory.NewEnvyLaptop("2GH", 1);

        }
    }
}
