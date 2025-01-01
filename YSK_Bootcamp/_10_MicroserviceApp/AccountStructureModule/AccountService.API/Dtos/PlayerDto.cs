namespace AccountService.API.Dtos
{
    public record PlayerCreateDto(string FirstName, string LastName, string Username);
    public record PlayerUpdateDto(string Id, string FirstName, string LastName, string Username);
}
