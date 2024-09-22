namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class int_8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
