namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "AdvertId");
            RenameColumn(table: "dbo.Address", name: "Id", newName: "AdvertId");
            RenameIndex(table: "dbo.Address", name: "IX_Id", newName: "IX_AdvertId");
            AlterColumn("dbo.Advert", "Header", c => c.String(maxLength: 64));
            AlterColumn("dbo.Advert", "Content", c => c.String());
            AlterColumn("dbo.Advert", "Footage", c => c.Int());
            AlterColumn("dbo.Advert", "IsReserved", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advert", "IsReserved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Advert", "Footage", c => c.Int(nullable: false));
            AlterColumn("dbo.Advert", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Advert", "Header", c => c.String(nullable: false, maxLength: 64));
            RenameIndex(table: "dbo.Address", name: "IX_AdvertId", newName: "IX_Id");
            RenameColumn(table: "dbo.Address", name: "AdvertId", newName: "Id");
            AddColumn("dbo.Address", "AdvertId", c => c.Long(nullable: false));
        }
    }
}
