namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoldierBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "BirthDate", c => c.DateTime(nullable: false));
        }
         
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "BirthDate");
        }
    }
}
