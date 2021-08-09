namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class FeeContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Fees
            var data = ofiCondoDbContext.Fees.Find(Guid.Parse(ConstantKeyValue.FeeID[0]));
            if (data == null)
            {
                ofiCondoDbContext.Fees.Add(new Fee
                {
                    FeeId = Guid.Parse(ConstantKeyValue.FeeID[0]),
                    Amount = 5000,
                    DateBegin = DateTime.Now,
                    Name = "CUOTA"
                });
            }
            data = ofiCondoDbContext.Fees.Find(Guid.Parse(ConstantKeyValue.FeeID[1]));
            if (data == null)
            {
                ofiCondoDbContext.Fees.Add(new Fee
                {
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    FeeId = Guid.Parse(ConstantKeyValue.FeeID[1]),
                    Amount = 6500,
                    DateBegin = DateTime.Now,
                    DateEnd = DateTime.Now.AddMonths(6),
                    Name = "CUOTA ESPECIAL"
                });                
            }
            ofiCondoDbContext.SaveChanges();
        }
    }
}
