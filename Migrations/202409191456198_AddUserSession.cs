namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SessionExpiry", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SessionExpiry");
        }
    }
}
