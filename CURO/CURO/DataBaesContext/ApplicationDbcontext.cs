using Microsoft.EntityFrameworkCore;
using CURO.Models;

namespace CURO.DataBaesContext
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbcontext).Assembly);
        }
        public DbSet<CURO.Models.Student> Student { get; set; } = default!;
    }
}
