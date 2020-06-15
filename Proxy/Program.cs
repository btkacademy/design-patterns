using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreditBase creditManager = new CreditManager();
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());
            Console.ReadKey();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 10; i++)
            {
                result *= i;
                Thread.Sleep(500);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if(_creditManager==null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}
