namespace OptiTech.Core.Entities
{
    public class InventoryItem
    {
        protected InventoryItem() { }

        public InventoryItem(Product product, int quantity)
        {
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
        }

        public int Id { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public void DecreaseStock(int amount)
        {
            if (amount > Quantity)
                throw new InvalidOperationException("Not enough stock");
            Quantity -= amount;
        }

        public void IncreaseStock(int amount)
        {
            Quantity += amount;
        }
    }
}
