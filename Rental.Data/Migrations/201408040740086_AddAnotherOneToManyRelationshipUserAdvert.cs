namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotherOneToManyRelationshipUserAdvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advert", "ReservatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Advert", "ReservatorId");
            AddForeignKey("dbo.Advert", "ReservatorId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advert", "ReservatorId", "dbo.User");
            DropIndex("dbo.Advert", new[] { "ReservatorId" });
            DropColumn("dbo.Advert", "ReservatorId");
        }
    }
}
