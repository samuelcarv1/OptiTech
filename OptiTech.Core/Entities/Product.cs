using OptiTech.Core.ValueObjects;

namespace OptiTech.Core.Entities
{
    public class Product
    {
        protected Product() { }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
    }
}
