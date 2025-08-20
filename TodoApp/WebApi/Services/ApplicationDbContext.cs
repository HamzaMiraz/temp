using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected ApplicationDbContext()
        //{
        //}
        public required DbSet<Event>Events { get; set; }
    }
}
