namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class velocity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LioOrders", "VelocityApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LioOrders", "VelocityApproved");
        }
    }
}
