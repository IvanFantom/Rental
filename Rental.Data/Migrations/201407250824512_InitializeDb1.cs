namespace Rental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "LastName", c => c.String(maxLength: 64));
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 128));
            DropColumn("dbo.User", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Surname", c => c.String(maxLength: 64));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.User", "LastName");
        }
    }
}
