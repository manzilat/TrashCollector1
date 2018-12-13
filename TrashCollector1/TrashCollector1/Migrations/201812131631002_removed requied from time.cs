namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiedfromtime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegularPickups", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegularPickups", "Time", c => c.String(nullable: false));
        }
    }
}
