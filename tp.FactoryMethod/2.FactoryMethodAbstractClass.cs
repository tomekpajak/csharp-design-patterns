using System;
using System.Collections.Generic;
using System.Text;

namespace tp.FactoryMethod.CaseAbstractClass
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
