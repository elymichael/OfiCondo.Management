namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Linq;

    public class IncomeContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            var data = ofiCondoDbContext.Incomes.Find(Guid.Parse(ConstantKeyValue.IncomeID));
            if (data == null)
            {
                var attachmentID = ofiCondoDbContext.Attachments
                    .FirstOrDefault(x => x.Name == "FileName").AttachmentId;

                // Income            
                ofiCondoDbContext.Incomes.Add(new Income
                {
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    IncomeId = Guid.Parse(ConstantKeyValue.IncomeID),
                    Description = "Pago de cuota apto 3A",
                    RecordDate = DateTime.Now,
                    AttachmentId = attachmentID,
                    Amount = 5000,
                    FeeId = Guid.Parse(ConstantKeyValue.FeeID[0]),
                    UnitId = Guid.Parse(ConstantKeyValue.UnitID),
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
