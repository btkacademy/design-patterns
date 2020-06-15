using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee manager1 = new Employee() { Name = "Yönetici1" };
            Employee employee1 = new Employee() { Name = "Çalışan1" };
            Employee employee2 = new Employee() { Name = "Çalışan2" };
            Employee employee3 = new Employee() { Name = "Çalışan3" };
            Contractor contractor1= new Contractor() { Name = "Dışçalışan1" };

            manager1.AddSubordinate(employee1);
            manager1.AddSubordinate(employee2);
            employee1.AddSubordinate(employee3);
            employee2.AddSubordinate(contractor1);

            Console.WriteLine(manager1.Name);
            foreach (Employee manager in manager1)
            {
                Console.WriteLine("\t"+manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("\t\t"+employee.Name);
                }
            }

            Console.ReadKey();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson, IEnumerable<IPerson>
    {
        public string Name { get; set; }
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
