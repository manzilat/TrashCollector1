namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcustomersforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularPickups", "CustomerId", "dbo.Customers");
            DropIndex("dbo.RegularPickups", new[] { "CustomerId" });
            DropColumn("dbo.RegularPickups", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularPickups", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.RegularPickups", "CustomerId");
            AddForeignKey("dbo.RegularPickups", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
