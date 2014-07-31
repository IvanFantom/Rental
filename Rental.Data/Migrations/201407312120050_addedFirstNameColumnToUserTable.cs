namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFirstNameColumnToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "FirstName");
        }
    }
}
