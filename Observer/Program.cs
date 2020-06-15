using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();

            Console.ReadKey();
        }
    }
    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Price updated");
            Notify();
        }
        public void Attach(Observer observer) => _observers.Add(observer);
        public void Detach(Observer observer) => _observers.Remove(observer);
        void Notify()
        {
            _observers.ForEach(x =>
            {
                x.Update();
            });
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("CustomerObserver price change");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("EmployeeObserver price change");
        }
    }

}
