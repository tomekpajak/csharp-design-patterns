using System;
using System.Collections.Generic;
using System.Text;

namespace tp.Prototype
{
    interface IPrototype<T>
    {
        T DeepCopy();
    }

    class EmployeeDeepCopy : IPrototype<EmployeeDeepCopy>
    {
        public string Name;
        public DepartmentDeepCopy Department;

        public EmployeeDeepCopy(string name, DepartmentDeepCopy department)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public EmployeeDeepCopy DeepCopy()
        {
            return new EmployeeDeepCopy(this.Name, this.Department.DeepCopy());
        }

        public override string ToString() =>
            $"{nameof(Name)}: {Name}; {nameof(Department)}: {Department.ToString()}";
    }

    class DepartmentDeepCopy : IPrototype<DepartmentDeepCopy>
    {
        public string Name;
        public DepartmentDeepCopy Parent;

        public DepartmentDeepCopy(string name, DepartmentDeepCopy parent)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent;
        }

        public DepartmentDeepCopy DeepCopy()
        {
            return new DepartmentDeepCopy(this.Name, this.Parent == null ? null : this.Parent.DeepCopy());
        }

        public override string ToString() =>
            string.Format("{0}: {1}; {2}: {3}", nameof(Name), Name, nameof(Parent), Parent!.Name ?? "null");
    }
}
