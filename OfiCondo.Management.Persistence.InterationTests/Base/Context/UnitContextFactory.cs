namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class UnitContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Units
            var data = ofiCondoDbContext.Units.Find(Guid.Parse(ConstantKeyValue.UnitID));
            if (data == null)
            {
                ofiCondoDbContext.Units.Add(new Unit
                {
                    UnitId = Guid.Parse(ConstantKeyValue.UnitID),
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    Name = "Apto 3A",
                    OwnerId = Guid.Parse(ConstantKeyValue.OwnerID)
                });
                ofiCondoDbContext.SaveChanges();
            }
        }
    }
}
