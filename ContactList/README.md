# contact-list
Web app to manage list of contacts

1.Configuration of connection to the database <br />
&ensp;- edit appsettings.json and change the content of "MSSqlConnection" <br />
2. Making changes to the database <br />
&ensp;- EntityFramework core docs https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli <br />
&ensp;- Create new migration with command: <br />
&ensp;&ensp;&ensp;'Add-Migration <name_of_migration> -Project ContactList.Presistence' <br />
&ensp;- Generate .sql script which should be executed later on the database <br />
&ensp;&ensp;&ensp;a) To create database: 'Script-Migration -From 0 -To <last_migration_name> <br />
&ensp;&ensp;&ensp;b) To update database: 'Script-Migration -From <older_migration_name> -To <newer_migration_name> <br />
