namespace MarketService.Data.Entities
{
    public class Market
    {
        public int Id { get; set; }

        public string ItemId { get; set; } = null!;

        public string InventoryId { get; set; } = null!;

        public decimal Price { get; set; }

        public string PlayerId { get; set; } = null!;

        public bool State { get; set; } = false;

    }
}
