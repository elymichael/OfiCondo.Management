namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class AttachmentContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Attachments
            var data = ofiCondoDbContext.Attachments.Find(Guid.Parse(ConstantKeyValue.AttachmentID));
            if (data == null)
            {
                ofiCondoDbContext.Attachments.Add(new Attachment
                {
                    AttachmentId = Guid.Parse(ConstantKeyValue.AttachmentID),
                    Data = new byte[1024],
                    Name = "FileName"
                });
                ofiCondoDbContext.SaveChanges();
            }
        }
    }
}
