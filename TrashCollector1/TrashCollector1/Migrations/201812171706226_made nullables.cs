namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madenullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SpecialPickupDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "AccountSuspendDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "AccountSuspendEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AccountSuspendEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "AccountSuspendDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SpecialPickupDate", c => c.DateTime(nullable: false));
        }
    }
}
