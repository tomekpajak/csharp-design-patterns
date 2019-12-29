using System;
using System.Collections.Generic;
using System.Text;

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
}
