using CarTryApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<CarSpecification> CarSpecifications { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<AdTag> CarAdTag { get; set; }
        public DbSet<CarFeedback> CarFeedbacks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<CustomerDetailType> CustomerDetailTypes { get; set; }
        public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public Context(DbContextOptions oprions) : base(oprions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AdTag>()
                .HasKey(a => new { a.AdId, a.TagId });

            builder.Entity<AdTag>()
                 .HasOne<Ad>(i => i.Ad)
                 .WithMany(i => i.AdTags)
                 .HasForeignKey(i => i.AdId);

            builder.Entity<AdTag>()
                .HasOne<Tag>(i => i.Tag)
                .WithMany(i => i.AdTags)
                .HasForeignKey(i => i.TagId);
        }
    }
}
