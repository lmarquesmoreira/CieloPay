namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidodecimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LioOrders", "LioResponseId", c => c.String());
            AlterColumn("dbo.LioOrders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LioOrders", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.LioOrders", "LioResponseId");
        }
    }
}
