Working with Management:
add-migration InitialMigration -Context OfiCondoDbContext
update-database -Context OfiCondoDbContext

Working with Identity:
add-migration InitialMigration -Context OfiCondoIdentityDbContext
update-database -Context OfiCondoIdentityDbContext