namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class AccountContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            var data = ofiCondoDbContext.Accounts.Find(Guid.Parse(ConstantKeyValue.UserAdminID));
            if (data == null)
            {
                ofiCondoDbContext.Accounts.Add(new Account
                {
                    AccountId = Guid.Parse(ConstantKeyValue.UserAdminID),
                    Name = "Ely Nunez",
                    Phone = "8096543131",
                    Email = "elymichael@gmail.com"
                });
            }
            ofiCondoDbContext.SaveChanges();
        }
    }
}
