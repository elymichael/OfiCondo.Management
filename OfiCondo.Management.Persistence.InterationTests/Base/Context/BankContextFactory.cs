namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class BankContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Banks
            var data = ofiCondoDbContext.Banks.Find(Guid.Parse(ConstantKeyValue.BankID));
            if (data == null)
            {
                ofiCondoDbContext.Banks.Add(new Bank
                {
                    AccountId = Guid.Parse(ConstantKeyValue.UserAdminID),
                    AccountNumber = "7845752244-1",
                    BankId = Guid.Parse(ConstantKeyValue.BankID),
                    Description = "Cuenta de Ahorro Edificio Banco La Fe",
                    Name = "Cuenta La Fe"
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
