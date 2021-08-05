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
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(OfiCondoDbContext).Assembly)
                .Initialize();

            modelBuilder.Entity<Condominium>().ToTable("Condominia")
               .HasMany(c => c.Units);               
                
            modelBuilder.Entity<Account>().ToTable("Accounts")
                .HasMany(c => c.Condominia);

            modelBuilder.Entity<Attachment>().ToTable("Attachments");
            modelBuilder.Entity<Bank>().ToTable("Banks");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Fee>().ToTable("Fees");
            modelBuilder.Entity<Income>().ToTable("Incomes");
            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Minute>().ToTable("Minutes");
            modelBuilder.Entity<Owner>().ToTable("Owners");
            modelBuilder.Entity<Payee>().ToTable("Payees");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            modelBuilder.Entity<Unit>().ToTable("Units");
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
    }
}
