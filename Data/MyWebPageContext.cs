using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Models;
using MyWebPage.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyWebPage.Data
{
    public class MyWebPageContext : IdentityDbContext<MyWebPageUser>
    {
        public MyWebPageContext (DbContextOptions<MyWebPageContext> options)
            : base(options)
        {
        }
 
        public DbSet<MyWebPage.Models.Movie>? Movies { get; set; }
        public DbSet<MyWebPage.Models.ApplicantDetails>? ApplicantDetails { get; set; }
        public DbSet<MyWebPage.Models.ApplicantSkills>? ApplicantSkills { get; set; }
        public DbSet<MyWebPage.Models.ApplicantWorkExperience>? ApplicantWorkExperiences { get; set; }
        public DbSet<MyWebPage.Models.Item>? Items { get; set; }
        public DbSet<MyWebPage.Models.AppFile>? AppFiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<ApplicantDetails>().ToTable("ApplicantDetails");
            builder.Entity<ApplicantSkills>().ToTable("ApplicantSkills");
            builder.Entity<ApplicantWorkExperience>().ToTable("ApplicantWorkExperience");
            builder.Entity<Item>().ToTable("Item");
            builder.Entity<AppFile>().ToTable("AppFile");

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
