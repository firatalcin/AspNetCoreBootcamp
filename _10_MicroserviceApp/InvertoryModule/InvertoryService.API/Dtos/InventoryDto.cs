namespace InvertoryService.API.Dtos
{
    public class InventoryDto
    {
        public record InventoryCreateDto(string PlayerId, string Name);
        public record ItemInventoryCreateDto(string InventoryId, string ItemId, int Count);
        public record ItemInventoryUpdateDto(string InventoryId, string ItemId, int Count);
    }
}
