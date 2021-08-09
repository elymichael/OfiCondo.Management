namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class OwnerContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            var data = ofiCondoDbContext.Owners.Find(Guid.Parse(ConstantKeyValue.OwnerID));
            if (data == null)
            {
                ofiCondoDbContext.Owners.Add(new Owner
                {
                    Name = "Ely Michael",
                    Email = "elymichael@gmail.com",
                    Phone = "8096543131",
                    OwnerId = Guid.Parse(ConstantKeyValue.OwnerID)
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
