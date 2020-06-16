using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetStubLogger());//new XLogger()
            customerManager.Save();

            Console.ReadKey();
        }
    }
    class CustomerManager
    {
        ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Save");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }
    class XLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("X logged");
        }
    }
    class YLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("X logged");
        }
    }
    class StubLogger : ILogger
    {
        #region Singleton
        static StubLogger _stubLogger;
        static object _lockObject=new object();
        private StubLogger() { }
        public static StubLogger GetStubLogger()
        {
            lock (_lockObject)
            {
                if (_stubLogger == null)
                    _stubLogger = new StubLogger();
            }
            return _stubLogger;
        }
        #endregion
        public void Log()
        {
        }
    }
}
