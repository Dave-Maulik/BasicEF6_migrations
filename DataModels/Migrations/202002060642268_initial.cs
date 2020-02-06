namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClanName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Soldiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServerdInSpecial = c.Boolean(nullable: false),
                        ClanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.ClanId, cascadeDelete: true)
                .Index(t => t.ClanId);
            
            CreateTable(
                "dbo.SoliderEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Solider_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Soldiers", t => t.Solider_Id, cascadeDelete: true)
                .Index(t => t.Solider_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoliderEquipments", "Solider_Id", "dbo.Soldiers");
            DropForeignKey("dbo.Soldiers", "ClanId", "dbo.Clans");
            DropIndex("dbo.SoliderEquipments", new[] { "Solider_Id" });
            DropIndex("dbo.Soldiers", new[] { "ClanId" });
            DropTable("dbo.SoliderEquipments");
            DropTable("dbo.Soldiers");
            DropTable("dbo.Clans");
        }
    }
}
