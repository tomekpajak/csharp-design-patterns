using System;

namespace tp.AbstractFactory
{
    enum LaptopBrand { apple = 'a', hp = 'h'};
    interface IProcessor
    {
        string GetProcessorDescription();
    }
    interface IStorage
    {
        string GetStorageDescription();
    }
    interface IBrandLaptopFactory
    {
        IProcessor CreateProcessor();
        IStorage CreateStorage();
    }
    class Laptop
    {
        public IProcessor Processor { get; set; }
        public IStorage Storage { get; set; }

        public string GetDescription() => 
            $"Laptop contains: {this.Processor.GetProcessorDescription()} and {this.Storage.GetStorageDescription()}";
    }

    class AppleProcessor : IProcessor
    {
        public string GetProcessorDescription() => "Processor: Apple";
    }
    class AppleStorage : IStorage
    {
        public string GetStorageDescription() => "Storage: Apple";
    }
    class AppleLaptopFactory : IBrandLaptopFactory
    {
        public IProcessor CreateProcessor() => new AppleProcessor();
        public IStorage CreateStorage() => new AppleStorage();
    }


    class IntelProcessor : IProcessor
    {
        public string GetProcessorDescription() => "Processor: Intel";
    }
    class HPStorage : IStorage
    {
        public string GetStorageDescription() => "Storage: HP";
    }
    class HPLaptopFactory : IBrandLaptopFactory
    {
        public IProcessor CreateProcessor() => new IntelProcessor();
        public IStorage CreateStorage() => new HPStorage();
    }

    class LaptopStore
    {
        public Laptop OrderLaptop(LaptopBrand brand)
        {
            return CreateLaptop(FactoryProvider(brand));
        }

        private IBrandLaptopFactory FactoryProvider(LaptopBrand brand)
        {
            IBrandLaptopFactory factory = null;

            switch (brand)
            {
                case LaptopBrand.apple:
                    factory = new AppleLaptopFactory();
                    break;
                case LaptopBrand.hp:
                    factory = new HPLaptopFactory();
                    break;
                default:
                    break;
            }

            return factory;
        }

        private Laptop CreateLaptop(IBrandLaptopFactory factory)
        {
            Laptop laptop = new Laptop();
            laptop.Processor = factory.CreateProcessor();
            laptop.Storage = factory.CreateStorage();

            return laptop;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What brand laptop do you want to buy? (a)pple or (h)p?");
            var brand = (LaptopBrand)Enum.ToObject(typeof(LaptopBrand), Console.ReadKey().KeyChar);

            var store = new LaptopStore();
            Laptop laptop = store.OrderLaptop(brand);

            Console.WriteLine("{0}{1}", Environment.NewLine, laptop.GetDescription());
        }
    }
}
        