namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.Byte(nullable: false));
        }
    }
}
