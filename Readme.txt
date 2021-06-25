Working with Management:
add-migration InitialMigration -Context OfiCondoDbContext
update-database -Context OfiCondoDbContext

Working with Identity:
add-migration InitialMigration -Context OfiCondoIdentityDbContext
update-database -Context OfiCondoIdentityDbContext

Working with API
Ready
--Bank
--Cateogry
--PaymentMethod
Pending
--Condominia
--Expenses
--Incomes
--Messages
--Minutes
--Units