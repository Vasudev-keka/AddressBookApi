using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users_Api { get; set; }
    }
}
