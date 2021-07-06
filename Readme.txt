Working with Management:
add-migration InitialMigration -Context OfiCondoDbContext
update-database -Context OfiCondoDbContext

Working with Identity:
add-migration InitialMigration -Context OfiCondoIdentityDbContext
update-database -Context OfiCondoIdentityDbContext

Working with API
Ready
--Bank
--Category
--Condominia
--Messages
--Minutes
--PaymentMethod
--Units
Pending
--Account (Review)
--Attachment
--Expenses
--Fee
--Incomes
--Owner (Review)
--Payees

**** Check validator classes. ****