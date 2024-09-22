namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceDetails", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "Discount");
            DropColumn("dbo.Invoices", "InvoiceDiscount");
        }
    }
}
