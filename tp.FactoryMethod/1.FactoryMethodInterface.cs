using System;
using System.Collections.Generic;
using System.Text;

namespace tp.FactoryMethod.CaseInterface
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
