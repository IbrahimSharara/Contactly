namespace Contactly.API.DTO.InputDTO
{
    public record AddContactDTO
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string PhoneNumber { get; set; }
        public bool Favourit { get; set; }
    }
}
