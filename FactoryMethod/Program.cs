using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadKey();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4net();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Xlogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }
    public class Log4net : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with log4net");
        }
    }
    public class Xlogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log with xlogger");
        }
    }

    public class CustomerManager
    {
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = new LoggerFactory2().CreateLogger();
            logger.Log();
        }
    }
}
