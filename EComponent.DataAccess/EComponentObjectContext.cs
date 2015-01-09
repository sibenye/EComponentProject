using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EComponent.DataAccess.DataModels;
using EComponent.Services.Repositories;

namespace EComponent.DataAccess
{
    public partial class EComponentObjectContext : DbContext
    {
        public EComponentObjectContext(string connectionName)
            : base(connectionName)
        {
        }

        public virtual DbSet<attribute> attributes { get; set; }
        public virtual DbSet<attributeValue> attributeValues { get; set; }
        public virtual DbSet<productCategory> productCategories { get; set; }
        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<attribute>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<attribute>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<attribute>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            //modelBuilder.Entity<attribute>()
            //    .HasMany(e => e.attributeValues)
            //    .WithRequired(e => e.attribute)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<attributeValue>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<attributeValue>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<attributeValue>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<productCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<productCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<productCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            //modelBuilder.Entity<productCategory>()
            //    .HasMany(e => e.products)
            //    .WithRequired(e => e.productCategory)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ManufacturerName)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ManufacturerPartNumber)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Pricing)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            //modelBuilder.Entity<product>()
            //    .HasMany(e => e.attributeValues)
            //    .WithRequired(e => e.product)
            //    .WillCascadeOnDelete(false);
        }
    }
}
