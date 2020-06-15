using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            //var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var product=builder.GetProduct();
            Console.WriteLine(product.Id);
            Console.WriteLine(product.CategoryName);
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.UnitPrice);
            Console.WriteLine(product.DiscountedPrice);
            Console.WriteLine(product.DiscountApplied);
            Console.ReadKey();
        }
    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    public abstract class ProductBuilder
    {
        protected ProductViewModel _model =new ProductViewModel();

        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public virtual ProductViewModel GetProduct()
        {
            return _model;
        }
    }
    public class NewCustomerProductBuilder : ProductBuilder
    {
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.CategoryName = "İçecek";
            _model.ProductName = "Su";
            _model.UnitPrice = 100;

        }
        public override void ApplyDiscount()
        {
            _model.DiscountedPrice = _model.UnitPrice * 0.90m;
            _model.DiscountApplied = true;
        }
    }
    public class OldCustomerProductBuilder : ProductBuilder
    {
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.CategoryName = "İçecek";
            _model.ProductName = "Su";
            _model.UnitPrice = 100;
        }
        public override void ApplyDiscount()
        {
            _model.DiscountedPrice = _model.UnitPrice;
            _model.DiscountApplied = false;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
