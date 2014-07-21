namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Country = c.String(nullable: false, maxLength: 64),
                        City = c.String(nullable: false, maxLength: 64),
                        District = c.String(nullable: false, maxLength: 128),
                        Street = c.String(nullable: false, maxLength: 128),
                        AdvertId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advert", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Advert",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 64),
                        Content = c.String(nullable: false),
                        Footage = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReserved = c.Boolean(nullable: false),
                        UserId = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        Surname = c.String(maxLength: 64),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "Id", "dbo.Advert");
            DropForeignKey("dbo.Advert", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Advert", new[] { "UserId" });
            DropIndex("dbo.Address", new[] { "Id" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Advert");
            DropTable("dbo.Address");
        }
    }
}
