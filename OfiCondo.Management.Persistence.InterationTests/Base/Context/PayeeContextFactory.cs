namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class PayeeContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            var data = ofiCondoDbContext.Payees.Find(Guid.Parse(ConstantKeyValue.PayeeID));
            if (data == null)
            {
                ofiCondoDbContext.Payees.Add(new Payee
                {
                    Name = "Juan Carrera",
                    Email = "jcarrera@gmail.com",
                    Phone = "8096875477",
                    AccountId = Guid.Parse(ConstantKeyValue.UserAdminID),
                    AccountNumber = "457854222-1",
                    PayeeId = Guid.Parse(ConstantKeyValue.PayeeID),
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
