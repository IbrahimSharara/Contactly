namespace Contactly.API.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string PhoneNumber { get; set; }
        public bool Favourit { get; set; }
    }
}
