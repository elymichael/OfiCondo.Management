namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class ExpenseContextFactory
    {
        public static void Initialize(
            OfiCondoDbContext ofiCondoDbContext)
        {
            // Messages
            var data = ofiCondoDbContext.Expenses.Find(Guid.Parse(ConstantKeyValue.ExpenseID));
            if (data == null)
            {
                ofiCondoDbContext.Expenses.Add(new Expense
                {
                    CondominiumId = Guid.Parse(ConstantKeyValue.CondominiumID),
                    ExpenseId = Guid.Parse(ConstantKeyValue.ExpenseID),
                    Description = "Compra de Gas",
                    RecordDate = DateTime.Now,
                    Amount = 100,
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[0]),
                    PayeeId = Guid.Parse(ConstantKeyValue.PayeeID),
                    PaymentMethodId = ConstantKeyValue.PaymentMethodID,
                    AttachmentId = Guid.Parse(ConstantKeyValue.AttachmentID)

                });
                ofiCondoDbContext.SaveChanges();
            }            
        }
    }
}
