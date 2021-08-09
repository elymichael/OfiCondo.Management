namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    public class CategoryContextFactory
    {
        public static void Initialize(OfiCondoDbContext ofiCondoDbContext)
        {
            // 1
            var data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[1]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[1]),
                    Name = "NOMINA"
                });
            }
            // 0
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[0]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[0]),
                    Name = "GASTO GENERAL"
                });
            }
            // 2
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[2]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[2]),
                    Name = "GAS"
                });
            }
            // 3
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[3]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[3]),
                    Name = "ENERGIA ELECTRICA"
                });
            }
            // 4
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[4]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[4]),
                    Name = "AGUA"
                });
            }
            // 5
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[5]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[5]),
                    Name = "LIMPIEZA"
                });
            }
            // 6
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[6]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[6]),
                    Name = "MANTENIMIENTO"
                });
            }
            // 7
            data = ofiCondoDbContext.Categories.Find(Guid.Parse(ConstantKeyValue.CategoryID[7]));

            if (data == null)
            {
                ofiCondoDbContext.Categories.Add(new Category
                {
                    CategoryId = Guid.Parse(ConstantKeyValue.CategoryID[7]),
                    Name = "REPARACION"
                });
            }
            ofiCondoDbContext.SaveChanges();
        }
    }
}
