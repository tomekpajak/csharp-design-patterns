using System;

namespace tp.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Prototype using ICloneable...");
            var administrativeDepartment = new DepartmentCloneable("Administrative Department", null);
            var HRSection = new DepartmentCloneable("HR Section", administrativeDepartment);
            var john = new EmployeeCloneable("John", HRSection);

            EmployeeCloneable tom = (EmployeeCloneable)john.Clone();
            tom.Name = "Tom";

            Console.WriteLine(john.ToString());
            Console.WriteLine(tom.ToString());

            Console.WriteLine("2. Prototype using copy constructors...");
            var administrativeDepartment2 = new DepartmentCopyConstructor("Administrative Department", null);
            var HRSection2 = new DepartmentCopyConstructor("HR Section", administrativeDepartment2);
            var john2 = new EmployeeCopyConstructor("John", HRSection2);

            EmployeeCopyConstructor tom2 = new EmployeeCopyConstructor(john2);
            tom2.Name = "Tom2";

            Console.WriteLine(john2.ToString());
            Console.WriteLine(tom2.ToString());

            Console.WriteLine("3. Prototype using own deep copy interface...");
            var administrativeDepartment3 = new DepartmentDeepCopy("Administrative Department", null);
            var HRSection3 = new DepartmentDeepCopy("HR Section", administrativeDepartment3);
            var john3 = new EmployeeDeepCopy("John", HRSection3);

            EmployeeDeepCopy tom3 = john3.DeepCopy();
            tom3.Name = "Tom3";

            Console.WriteLine(john3.ToString());
            Console.WriteLine(tom3.ToString());

            Console.WriteLine("4. Prototype using serialization...");
            var administrativeDepartment4 = new DepartmentSerialization("Administrative Department", null);
            var HRSection4 = new DepartmentSerialization("HR Section", administrativeDepartment4);
            var john4 = new EmployeeSerialization("John", HRSection4);

            EmployeeSerialization tom4 = john4.DeepCopyByBinaryFormatter();
            tom4.Name = "Tom4";
            EmployeeSerialization tom5 = john4.DeepCopyByXmlSerializer();
            tom5.Name = "Tom5";
            EmployeeSerialization tom6 = john4.DeepCopyByJsonSerializer();
            tom6.Name = "Tom6";

            Console.WriteLine(john4.ToString());
            Console.WriteLine(tom4.ToString());
            Console.WriteLine(tom5.ToString());
            Console.WriteLine(tom6.ToString());
        }
    }
}
