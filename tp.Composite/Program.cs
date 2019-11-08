using System;
using System.Collections;
using System.Collections.Generic;

namespace tp.Composite
{
    interface IOrganizationalUnit
    {
        int GetEmployeesCount();
    }

    class TeamProjectA : IOrganizationalUnit
    {
        public int GetEmployeesCount() => 2;
    }
    class TeamProjectB : IOrganizationalUnit
    {
        public int GetEmployeesCount() => 10;
    }
    class TeamProjectC : IOrganizationalUnit
    {
        public int GetEmployeesCount() => 5;
    }
    class OrganizationalUnitComposite : IOrganizationalUnit
    {
        private IList<IOrganizationalUnit> organizationalUnits = new List<IOrganizationalUnit>();
        public void Add(IOrganizationalUnit organizationalUnit) => this.organizationalUnits.Add(organizationalUnit);
        public int GetEmployeesCount()
        {
            int result = 0;
            foreach (var unit in organizationalUnits)
                result += unit.GetEmployeesCount();

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var departmentA = new OrganizationalUnitComposite();
            departmentA.Add(new TeamProjectA());
            departmentA.Add(new TeamProjectB());

            var companyA = new OrganizationalUnitComposite();
            companyA.Add(departmentA);
            companyA.Add(new TeamProjectC());

            Console.WriteLine(companyA.GetEmployeesCount());
        }
    }
}
