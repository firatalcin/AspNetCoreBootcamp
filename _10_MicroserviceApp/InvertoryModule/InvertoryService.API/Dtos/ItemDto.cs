namespace InvertoryService.API.Dtos
{
    public class ItemDto
    {
        public record ItemCreateDto(string Name);
        public record ItemUpdateDto(string Id, string Name);
    }
}
