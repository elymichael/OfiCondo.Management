namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class MinuteContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Minutes
            var data = ofiCondoDbContext.Minutes.Find(Guid.Parse(ConstantKeyValue.MinuteID));
            if (data == null)
            {
                ofiCondoDbContext.Minutes.Add(new Minute
                {
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    MinuteId = Guid.Parse(ConstantKeyValue.MinuteID),
                    Description = "Reunión de inquilinos",
                    Title = "Reunión",
                    RecordDate = DateTime.Now
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
