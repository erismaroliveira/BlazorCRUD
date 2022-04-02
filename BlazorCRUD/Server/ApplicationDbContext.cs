using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
