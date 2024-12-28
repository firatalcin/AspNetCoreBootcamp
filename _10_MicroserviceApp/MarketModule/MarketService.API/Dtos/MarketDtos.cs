namespace MarketService.API.Dtos
{
    public class MarketDtos
    {
        public record CreateMarketDto(string ItemId, string InventoryId, decimal Price, string PlayerId);
    }
}
