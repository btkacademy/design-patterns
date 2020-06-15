using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar
            {
                Make = "BMW",
                Model = "3.20",
                HirePrice = 2500
            };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 20;

            Console.WriteLine("Concrete : " + personelCar.HirePrice);
            Console.WriteLine("Special offer : " + specialOffer.HirePrice);
            Console.ReadKey();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        CarBase _carbase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carbase = carBase;
        }
    }
    class SpecialOffer : CarDecoratorBase
    {
        CarBase _carbase;
        public int DiscountPercentage { get; set; }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get { return _carbase.HirePrice - _carbase.HirePrice * DiscountPercentage / 100; }
            set
            {
                _carbase.HirePrice = value;
            }
        }
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carbase = carBase;
        }
    }
}
