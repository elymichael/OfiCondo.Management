namespace OfiCondo.Management.Persistence.InterationTests.Base
{
    using OfiCondo.Management.Identity;
    using OfiCondo.Management.Persistence.InterationTests.Base.Context;
    using System;
    public class ContextFactory
    {
        public static void InitializeDbForTests(OfiCondoDbContext ofiCondoDbContext)
        {
            // Attachments
            AttachmentContextFactory.Initialize(ofiCondoDbContext);
            // Payments            
            PaymentMethodContextFactory.Initialize(ofiCondoDbContext);
            // Categories
            CategoryContextFactory.Initialize(ofiCondoDbContext);
            // Accounts
            AccountContextFactory.Initialize(ofiCondoDbContext);
            // Condominia
            CondominiaContextFactory.Initialize(ofiCondoDbContext);
            // Owners
            OwnerContextFactory.Initialize(ofiCondoDbContext);
            // Unit
            UnitContextFactory.Initialize(ofiCondoDbContext);
            // Banks
            BankContextFactory.Initialize(ofiCondoDbContext);
            // Fees
            FeeContextFactory.Initialize(ofiCondoDbContext);
            // Payees
            PayeeContextFactory.Initialize(ofiCondoDbContext);
            // Incomes
            IncomeContextFactory.Initialize(ofiCondoDbContext);
            // Expenses
            ExpenseContextFactory.Initialize(ofiCondoDbContext);
            // Minutes
            MinuteContextFactory.Initialize(ofiCondoDbContext);
            // Messages
            MessageContextFactory.Initialize(ofiCondoDbContext);
        }

        public static void InitializeDbForTests(OfiCondoIdentityDbContext ofiCondoDbContext)
        {
            // User ID.
            string userAdminID = Guid.NewGuid().ToString();
            // Identity Initialization.
            IdentityContextFactory.Initialize(ofiCondoDbContext, userAdminID);
        }
    }
}
