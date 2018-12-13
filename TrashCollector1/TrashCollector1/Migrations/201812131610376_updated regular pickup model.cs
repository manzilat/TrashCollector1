namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedregularpickupmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularPickups", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularPickups", "Time");
        }
    }
}
