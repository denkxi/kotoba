using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        // public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Language> Languages { get; set; }


        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        //     List<IdentityRole> roles = new List<IdentityRole>
        //     {
        //         new IdentityRole
        //         {
        //             Name = "Admin",
        //             NormalizedName = "ADMIN"
        //         },
        //         new IdentityRole
        //         {
        //             Name = "User",
        //             NormalizedName = "USER"
        //         }
        //     };
        //     builder.Entity<IdentityRole>().HasData(roles);
        // }

    }
}