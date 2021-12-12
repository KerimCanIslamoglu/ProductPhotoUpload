using EcommercePhotoUpload.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=ProductPhotoUploadDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Color>()
                        .HasMany(c => c.ProductDetails)
                        .WithOne(e => e.Color);

            modelBuilder.Entity<Fabric>()
                      .HasMany(c => c.ProductDetails)
                      .WithOne(e => e.Fabric);

            modelBuilder.Entity<Product>()
                      .HasMany(c => c.ProductDetails)
                      .WithOne(e => e.Product);


            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  Id = 1,
                  ProductName = "LOTR t-shirt"
              },
              new Product
              {
                  Id = 2,
                  ProductName = "Avengers t-shirt"
              },
              new Product
              {
                  Id = 3,
                  ProductName = "Star wars t-shirt"
              });


            modelBuilder.Entity<Color>().HasData(
             new Color
             {
                 Id = 1,
                 ColorName = "White"
             },
             new Color
             {
                 Id = 2,
                 ColorName = "Yellow"
             },
             new Color
             {
                 Id = 3,
                 ColorName = "Green"
             });


            modelBuilder.Entity<Fabric>().HasData(
            new Fabric
            {
                Id = 1,
                FabricName = "Cotton"
            },
            new Fabric
            {
                Id = 2,
                FabricName = "Linen"
            },
            new Fabric
            {
                Id = 3,
                FabricName = "Silk"
            });



            modelBuilder.Entity<ProductDetail>().HasData(
             new ProductDetail
             {
                 Id = 1,
                 ColorId=1,
                 FabricId=1,
                 ProductId=1,
                 ImageName= "red-tshirt.jpg",
                 ImageUrl= "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 2,
                 ColorId = 2,
                 FabricId = 2,
                 ProductId = 1,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 3,
                 ColorId = 3,
                 FabricId = 3,
                 ProductId = 1,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 4,
                 ColorId = 1,
                 FabricId = 2,
                 ProductId = 2,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 5,
                 ColorId = 2,
                 FabricId = 1,
                 ProductId = 2,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 6,
                 ColorId = 3,
                 FabricId = 2,
                 ProductId = 2,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 7,
                 ColorId = 2,
                 FabricId = 3,
                 ProductId = 2,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 8,
                 ColorId = 2,
                 FabricId = 1,
                 ProductId = 3,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
             new ProductDetail
             {
                 Id = 9,
                 ColorId = 1,
                 FabricId = 1,
                 ProductId = 3,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             },
              new ProductDetail
              {
                  Id = 10,
                  ColorId = 2,
                  FabricId = 3,
                  ProductId = 3,
                  ImageName = "red-tshirt.jpg",
                  ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
              },
             new ProductDetail
             {
                 Id = 11,
                 ColorId = 3,
                 FabricId = 1,
                 ProductId = 3,
                 ImageName = "red-tshirt.jpg",
                 ImageUrl = "/Resources/images/637749240795000805_red-tshirt.jpg"
             }
             );




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fabric> Fabric { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
    }
}
