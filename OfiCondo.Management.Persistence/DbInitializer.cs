namespace OfiCondo.Management.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Domain.Entities;
    using System;

    public static class DbInitializer
    {
        public static void Initialize(this ModelBuilder modelBuilder)
        {
            // Add Payment initial data.
            AddPaymentMethods(modelBuilder);
            // Add Category initial data.
            AddCategory(modelBuilder);
            // Add Fee initial data.
            AddFee(modelBuilder);
        }

        private static void AddPaymentMethods(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 1,
                Name = "TARJETA DE CREDITO",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 2,
                Name = "CHEQUE",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 3,
                Name = "EFECTIVO",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 4,
                Name = "TRANSFERENCIA",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
        }

        private static void AddCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("8BA73EB1-0E88-454B-B20E-FCDADF405195"),
                Name = "NOMINA",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("B5FB81FE-D640-4101-89CD-BA6FAF6463D4"),
                Name = "GASTO GENERAL",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("841DDD4E-23B1-4FC4-B8DD-BB19F1286350"),                
                Name = "GAS",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("AAB5B9D3-E97E-4F7B-932F-5F345476D88D"),
                Name = "ENERGIA ELECTRICA",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("F1248F07-8A7A-4A93-A028-7E64BAFFA8A9"),
                Name = "AGUA",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("E95B79FA-08A0-48FA-A896-40FE58EBCD6D"),
                Name = "LIMPIEZA",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("D9BB58BC-D171-42EF-9C81-6DE0FF5C83FA"),
                Name = "MANTENIMIENTO",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.Parse("07E593FE-3623-446A-AAB6-725433D7B5E7"),
                Name = "REPARACION",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });
        }

        private static void AddFee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fee>().HasData(new Fee
            {
                FeeId = Guid.Parse("29371840-82F8-4E77-B8BC-0D344B7DFB10"),
                Amount = 5000,
                DateBegin = DateTime.Now,
                Name = "CUOTA",                
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });

        }
    }
}
