using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = CustomerManager.CreateManager();
            customerManager.TestMethod();
            Console.ReadKey();
        }
    }
    public class CustomerManager
    {
        static CustomerManager _customerManager;
        static object _lockObject=new object();
        private CustomerManager() { }
        public static CustomerManager CreateManager()
        {
            lock(_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
        public void TestMethod()
        {
            Console.WriteLine("Test metot çalıştı");
        }
    }
}
