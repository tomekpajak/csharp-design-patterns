using System;
using System.Collections.Generic;
using System.Text;

namespace tp.FactoryMethod
{
    class LaptopInnerClass
    {
        public string Processor;
        public int StorageInGB;
        public HPLaptopModel Model;

        private LaptopInnerClass(string processor, int storageInGB, HPLaptopModel model)
        //public Laptop(string processor, string storage, HPLaptopModel model)
        {
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
            StorageInGB = storageInGB;
            Model = model;
        }

        //similar to
        //Task.Factory.StartNew...

        public static class Factory
        {
            public static LaptopInnerClass NewEnvyLaptop(string processor, int storageInTB) =>
                new LaptopInnerClass(processor, storageInTB * 1024, HPLaptopModel.envy);

            public static LaptopInnerClass NewPavilionLaptop(string processor, int storageInGigabyte) =>
                new LaptopInnerClass(processor, storageInGigabyte, HPLaptopModel.pavilion);
        }
    }
}
