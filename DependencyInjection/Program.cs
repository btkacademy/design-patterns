using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new YProductDal());//new XProductDal()
            productManager.Save();
            Console.ReadKey();
        }
    }
    interface IProductDal
    {
        void AddOrUpdate();
    }
    class XProductDal : IProductDal
    {
        public void AddOrUpdate()
        {
            Console.WriteLine("added by x");
        }
    }
    class YProductDal : IProductDal
    {
        public void AddOrUpdate()
        {
            Console.WriteLine("added by y");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.AddOrUpdate();
        }
    }
}
