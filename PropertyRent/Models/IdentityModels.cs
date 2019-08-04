using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PropertyRent.Models
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

    public class PropertyIdentity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Property")]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Added")]
        public System.DateTime DateCreated { get; set; } = System.DateTime.Now;

    }

    public class EnquiryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Enquiry")]
        public string Body { get; set; }

        [Required]
        public System.DateTime DateSent { get; set; } = System.DateTime.Now;

        public virtual ApplicationUser User { get; set; }

        public virtual PropertyIdentity Property { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<PropertyIdentity> Properties{ get; set; }
        public DbSet<EnquiryModel> Enquiries { get; set; }
    }
}