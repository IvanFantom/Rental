namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "AdvertId", "dbo.Advert");
            AddForeignKey("dbo.Address", "AdvertId", "dbo.Advert", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "AdvertId", "dbo.Advert");
            AddForeignKey("dbo.Address", "AdvertId", "dbo.Advert", "Id");
        }
    }
}
