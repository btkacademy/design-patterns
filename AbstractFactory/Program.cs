using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadKey();
        }
    }
    #region Logger class
    public abstract class Logging
    {
        public abstract void Log();
    }
    public class Log4Net : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Log with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Log with NLogger");
        }
    }
    #endregion
    #region Cache class
    public abstract class Caching
    {
        public abstract void Cache();
    }
    public class MemCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached with RedisCache ");
        }
    }
    #endregion
    #region Factory class
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4Net();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    #endregion
    public class ProductManager
    {
        CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        Logging _logging;
        Caching _caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            Console.WriteLine("Product listed");
            _logging.Log();
            _caching.Cache();
        }
    }

}
