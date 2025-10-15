namespace OptiTech.Infrastructure.Messaging.Events
{
    public class InventoryUpdatedEvent
    {
        public int idProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
