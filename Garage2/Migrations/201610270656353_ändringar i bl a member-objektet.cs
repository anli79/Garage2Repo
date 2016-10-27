namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ändringariblamemberobjektet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "ActiveMemberShip", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Members", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "PNr", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "PNr", c => c.String());
            AlterColumn("dbo.Members", "Address", c => c.String());
            AlterColumn("dbo.Members", "Name", c => c.String());
            DropColumn("dbo.Members", "ActiveMemberShip");
        }
    }
}
