using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LexMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LexMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<EmailSetting> EmailSetting { get; set; }
        public DbSet<MailBodyContent> MailBodyContent { get; set; }
        public DbSet<Privacy> Privacy { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SiteSetting> SiteSetting { get; set; }
        public DbSet<Warranty> Warranty { get; set; }
        public DbSet<NavlinkSetup> NavlinkSetup { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}