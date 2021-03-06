# OfiCondo Management Project
Application created to manage condominiums and apartments. This applicatin will handle the administration of the condominia with the apartments and the owner. This project was worked using "clean architecture" and it's supported for some open source libraries suggested for clean architects. The open source libraries used are:
- [x] **Serilog:** to log errors and information from the infrastucture project.
- [x] **Swashbuckle:** for testing purpose.
- [x] **JwtBearer:** for authorization and authentication.
- [x] **SendGrid:** for mailing process.
- [x] **AutoMapper:** convert object from one type to another object.
- [x] **FluentValidation:** validation library for building strongly-typed validation rules.
- [x] **MediatR:** the mediator pattern defines an object that encapsulates how a set of objects interact

## Working with Database
### Create database
This is the main database of the application, it has the complete logic of the application.
```
Working with Management:
add-migration InitialMigration -Context OfiCondoDbContext
update-database -Context OfiCondoDbContext
```

### Create database
it has the identity configuration to keep the users and json token generated to login in the application.
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

https://docs.docker.com/samples/dotnetcore/
