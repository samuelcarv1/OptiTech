using OptiTech.Core.Entities;
using OptiTech.Core.ValueObjects;

namespace OptiTech.Core.Aggregates
{
    public class Order
    {
        protected Order() { }

        public Order(Customer customer)
        {
            Customer = customer;
            Items = new List<OrderItem>();
            Total = new Money(0);
        }

        public int Id { get; private set; }

        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public Money Total { get; private set; } = new Money(0);

        public void AddItem(Product product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
            Total = Total.Add(new Money(product.Price.Amount * quantity, product.Price.Currency));
        }
    }

    public class OrderItem
    {
        protected OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
    }
}
