using System;
using System.Collections.Generic;
using System.Text;

namespace tp.FactoryMethod
{
    class LaptopPrivateConstructor
    {
        public string Processor;
        public int StorageInGB;
        public HPLaptopModel Model;
        
        private LaptopPrivateConstructor(string processor, int storageInGB, HPLaptopModel model)
        //public Laptop(string processor, string storage, HPLaptopModel model)
        {
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
            StorageInGB = storageInGB;
            Model = model;
        }

        public static LaptopPrivateConstructor NewEnvyLaptop(string processor, int storageInTB) => 
            new LaptopPrivateConstructor(processor, storageInTB * 1024, HPLaptopModel.envy);

        public static LaptopPrivateConstructor NewPavilionLaptop(string processor, int storageInGigabyte) =>
            new LaptopPrivateConstructor(processor, storageInGigabyte, HPLaptopModel.pavilion);
    }
}
