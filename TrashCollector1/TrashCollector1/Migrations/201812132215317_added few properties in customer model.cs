namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfewpropertiesincustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MoneyOwed", c => c.Double());
            AddColumn("dbo.Customers", "IsConfirmed", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsConfirmed");
            DropColumn("dbo.Customers", "MoneyOwed");
        }
    }
}
