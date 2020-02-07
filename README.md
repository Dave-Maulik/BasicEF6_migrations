# BasicEF6_migrations# BasicEF6_migrations
Console application to Demonstrate code fisrst migrations, By table Which aslo has navigation Properties.

# To get Started : 
##  Disable Database initializer.

* 1.Goto : BasicEF6_migrations/ConsoleToHandle/Program.cs 
* 2.Goto : Main() method.
* 3.Remove of Comment Following Line.

```c#
 Database.SetInitializer(new NullDatabaseInitializer<SoldierContext>());
 ```
 Good to go..
 
 ## About Projects inside EntityFrameworkSoldierdb
 ### BasicEF6_migrations
 BasicEF6_migrations is a Framework Class library (.Net Framework) contains the logical design of Database, contains model classes (Soldier class, Clan Class, and SoliderEquipment Classes With their Navigation Properties).
 Project Also Contains Enums used for listing the default for properties.
 
 ### ConsoleToHandle
 ConsoleToHandle is a console app containig the Core LINQ Queries.(Program.cs)
 
 ### DataModel 
 DataModel Also a Framework Class library (.Net Framework) contains the context object of Entity Framework and migration history.
 

