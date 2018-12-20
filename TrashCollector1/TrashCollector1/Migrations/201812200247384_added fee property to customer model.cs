namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfeepropertytocustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Fee", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Fee");
        }
    }
}
