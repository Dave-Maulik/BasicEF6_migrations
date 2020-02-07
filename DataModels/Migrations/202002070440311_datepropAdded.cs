namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Soldiers", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Soldiers", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Soldiers", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.SoliderEquipments", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SoliderEquipments", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.SoliderEquipments", "isDirty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoliderEquipments", "isDirty");
            DropColumn("dbo.SoliderEquipments", "DateModified");
            DropColumn("dbo.SoliderEquipments", "DateCreated");
            DropColumn("dbo.Soldiers", "isDirty");
            DropColumn("dbo.Soldiers", "DateModified");
            DropColumn("dbo.Soldiers", "DateCreated");
            DropColumn("dbo.Clans", "isDirty");
            DropColumn("dbo.Clans", "DateModified");
            DropColumn("dbo.Clans", "DateCreated");
        }
    }
}
