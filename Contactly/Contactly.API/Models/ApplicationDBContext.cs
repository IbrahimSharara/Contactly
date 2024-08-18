using Microsoft.EntityFrameworkCore;

namespace Contactly.API.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions op):base(op)
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
