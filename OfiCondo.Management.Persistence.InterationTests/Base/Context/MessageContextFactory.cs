namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class MessageContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Messages
            var data = ofiCondoDbContext.Messages.Find(Guid.Parse(ConstantKeyValue.MessageID));
            if (data == null)
            {
                ofiCondoDbContext.Messages.Add(new Message
                {
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    MessageId = Guid.Parse(ConstantKeyValue.MessageID),
                    Description = "Reunión",
                    RecordDate = DateTime.Now
                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
