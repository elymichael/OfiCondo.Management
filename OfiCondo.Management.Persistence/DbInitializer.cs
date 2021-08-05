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
                Name = "TARJETA DE CREDITO"
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 2,
                Name = "CHEQUE"
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 3,
                Name = "EFECTIVO"
            });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod
            {
                PaymentMethodId = 4,
                Name = "TRANSFERENCIA"
            });
        }

        private static void AddCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "NOMINA"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "GASTO GENERAL"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "GAS"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "ENERGIA ELECTRICA"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "AGUA"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "LIMPIEZA"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "MANTENIMIENTO"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "REPARACION"
            });
        }

        private static void AddFee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fee>().HasData(new Fee
            {
                FeeId = Guid.NewGuid(),
                Amount = 5000,
                DateBegin = DateTime.Now,
                Name = "CUOTA"
            });

        }
    }
}
