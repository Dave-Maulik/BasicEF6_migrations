namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIsDirty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clans", "isDirty");
            DropColumn("dbo.Soldiers", "isDirty");
            DropColumn("dbo.SoliderEquipments", "isDirty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SoliderEquipments", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Soldiers", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clans", "isDirty", c => c.Boolean(nullable: false));
        }
    }
}
