using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadKey();
        }
    }
    public class ProductManager
    {
        ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log();
            Console.WriteLine("Saved");
        }
    }

    public interface ILogger
    {
        void Log();
    }
    public class XLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with XLogger");
        }
    }

    //Nuget 
    public class Log4Net
    {
        public void Logging() => Console.WriteLine("Log with Log4Net");
    }

    public class Log4NetAdapter : ILogger
    {
        Log4Net _log4Net = new Log4Net();
        public void Log()
        {
            _log4Net.Logging();
        }
    }
}
