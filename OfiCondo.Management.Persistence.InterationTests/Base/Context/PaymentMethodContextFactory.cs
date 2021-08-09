namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Domain.Entities;
    public class PaymentMethodContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // Payment Methods
            var p1 = new PaymentMethod
            {
                PaymentMethodId = 1,
                Name = "TARJETA DE CREDITO"
            };
            var p2 = new PaymentMethod
            {
                PaymentMethodId = 2,
                Name = "CHEQUE"
            };
            var p3 = new PaymentMethod
            {
                PaymentMethodId = 3,
                Name = "EFECTIVO"
            };
            var p4 = new PaymentMethod
            {
                PaymentMethodId = 4,
                Name = "TRANSFERENCIA"
            };

            ofiCondoDbContext.PaymentMethods.Add(p1);
            ofiCondoDbContext.PaymentMethods.Add(p2);
            ofiCondoDbContext.PaymentMethods.Add(p3);
            ofiCondoDbContext.PaymentMethods.Add(p4);

            ofiCondoDbContext.Entry<PaymentMethod>(p1).State = EntityState.Detached;
            ofiCondoDbContext.Entry<PaymentMethod>(p2).State = EntityState.Detached;
            ofiCondoDbContext.Entry<PaymentMethod>(p3).State = EntityState.Detached;
            ofiCondoDbContext.Entry<PaymentMethod>(p4).State = EntityState.Detached;

            ofiCondoDbContext.SaveChanges();
        }
    }
}
