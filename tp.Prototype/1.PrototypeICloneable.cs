using System;
using System.Collections.Generic;
using System.Text;

namespace tp.Prototype
{
    //ICloneable problems:
    // - does not specify whether cloning should be shallow or deep so we don't know what to expect
    // - return object type intead of strong type
    // - description of Array.Clone: "Creates a shallow copy of the System.Array" 
    //   so if we have shallow copying here, why should we do something more?

    class EmployeeCloneable : ICloneable
    {
        public string Name;
        public DepartmentCloneable Department;

        public EmployeeCloneable(string name, DepartmentCloneable department)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public object Clone() => new EmployeeCloneable(Name, (DepartmentCloneable)Department.Clone());

        public override string ToString() =>
            $"{nameof(Name)}: {Name}; {nameof(Department)}: {Department.ToString()}";
    }

    class DepartmentCloneable : ICloneable
    {
        public string Name;
        public DepartmentCloneable Parent;

        public DepartmentCloneable(string name, DepartmentCloneable parent)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent;
        }

        public object Clone() =>
            new DepartmentCloneable(Name, Parent == null ? null : (DepartmentCloneable)Parent.Clone());

        public override string ToString() =>
            string.Format("{0}: {1}; {2}: {3}", nameof(Name), Name, nameof(Parent), Parent!.Name ?? "null");
    }
}
