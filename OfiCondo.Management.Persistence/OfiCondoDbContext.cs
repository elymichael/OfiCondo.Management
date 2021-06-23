namespace OfiCondo.Management.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Application.Contracts;
    using OfiCondo.Management.Domain.Common;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public class OfiCondoDbContext: DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        public OfiCondoDbContext(DbContextOptions<OfiCondoDbContext> options) : base(options)
        {
        }

        public OfiCondoDbContext(DbContextOptions<OfiCondoDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condominium> Condominia { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Minute> Minutes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OfiCondoDbContext).Assembly);
            // Add Payment Methods initial data.
            AddPaymentMethods(modelBuilder);
            // Add Category initial data.
            AddCategory(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddPaymentMethods(ModelBuilder modelBuilder)
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

        private void AddCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "NOMINA"                
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = "GENERAL"
            });
        }
    }
}
