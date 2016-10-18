namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Receipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Price");
        }
    }
}
