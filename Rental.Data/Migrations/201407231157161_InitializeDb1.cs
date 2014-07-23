namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Address", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "Id", c => c.Long(nullable: false));
        }
    }
}
