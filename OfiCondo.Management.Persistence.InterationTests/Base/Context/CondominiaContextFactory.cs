namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class CondominiaContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Condominia
            var data = ofiCondoDbContext.Condominia.Find(Guid.Parse(ConstantKeyValue.CondominiumID));
            if (data == null)
            {
                ofiCondoDbContext.Condominia.Add(new Condominium
                {
                    AccountId = Guid.Parse(ConstantKeyValue.UserAdminID),
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    Address = "Calle Macao #9",
                    Name = "Ethan 8",
                    Quantity = 8
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
