# contact-list
Web app to manage list of contacts

1.Configuration of connection to the database
	- edit appsettings.json and change the content of "MSSqlConnection"
2. Making changes to the database
	- EntityFramework core docs https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
	- Create new migration with command:
		'Add-Migration <name_of_migration> -Project ContactList.Presistence'
	- Generate .sql script which should be executed later on the database
		a) To create database: 'Script-Migration -From 0 -To <last_migration_name>
		b) To update database: 'Script-Migration -From <older_migration_name> -To <newer_migration_name>