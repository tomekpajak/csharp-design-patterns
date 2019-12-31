using System;
using System.Collections.Generic;
using System.Text;

namespace tp.Prototype
{
    class EmployeeCopyConstructor
    {
        public string Name;
        public DepartmentCopyConstructor Department;

        public EmployeeCopyConstructor(string name, DepartmentCopyConstructor department)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public EmployeeCopyConstructor(EmployeeCopyConstructor otherEmployee)
        {
            this.Name = otherEmployee.Name;
            this.Department = new DepartmentCopyConstructor(otherEmployee.Department);
        }

        public override string ToString() =>
            $"{nameof(Name)}: {Name}; {nameof(Department)}: {Department.ToString()}";
    }

    class DepartmentCopyConstructor
    {
        public string Name;
        public DepartmentCopyConstructor Parent;

        public DepartmentCopyConstructor(string name, DepartmentCopyConstructor parent)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent;
        }

        public DepartmentCopyConstructor(DepartmentCopyConstructor otherDepartment)
        {
            this.Name = otherDepartment.Name;
            this.Parent = otherDepartment.Parent == null ? null : new DepartmentCopyConstructor(otherDepartment.Parent);
        }

        public override string ToString() =>
            string.Format("{0}: {1}; {2}: {3}", nameof(Name), Name, nameof(Parent), Parent!.Name ?? "null");
    }
}
