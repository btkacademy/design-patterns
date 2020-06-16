using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager ahmet = new Manager
            {
                Name = "Ahmet",
                Salary = 1000
            };
            Manager aygn = new Manager
            {
                Name = "Aygün",
                Salary = 1100
            };
            Manager can = new Manager
            {
                Name = "can",
                Salary = 900
            };
            Worker leyla = new Worker
            {
                Name = "Leyla",
                Salary = 800
            };
            Worker ali = new Worker
            {
                Name = "Ali",
                Salary = 800
            };

            ahmet.Subordinates.Add(can);
            can.Subordinates.Add(aygn);
            aygn.Subordinates.Add(leyla);
            aygn.Subordinates.Add(ali);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(ahmet);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
            Console.ReadKey();
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(string.Format("{0} ödendi {1}", worker.Name, worker.Salary));
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(string.Format("{0} ödendi {1} [yöneticiye]", manager.Name, manager.Salary));
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine(string.Format("{0} zam yapıldı {1}", worker.Name, worker.Salary * 1.1));
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine(string.Format("{0} zam yapıldı {1} [yöneticiye]", manager.Name, manager.Salary * 1.2));
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

}
