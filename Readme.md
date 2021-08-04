# OfiCondo Management Project
Application created to manage condominiums and apartments.

## Working with Database
### Create database
```
Working with Management:
add-migration InitialMigration -Context OfiCondoDbContext
update-database -Context OfiCondoDbContext
```

### Create database
```
Working with Identity:
add-migration InitialMigration -Context OfiCondoIdentityDbContext
update-database -Context OfiCondoIdentityDbContext
```

## Project Status
```
Working with API
Ready
--Bank: it stores the bank accounts used for payments.
--Category: the category of the expenses registered in the system.
--Condominia: it's the block of units that conform a condominium.
--Expenses
--Fee
--Incomes
--Messages
--Minutes
--Payees
--PaymentMethod
--Units
Pending
--Account (Review)
--Attachment
--Owner (Review)
****
**** Check validator classes. ****
```
