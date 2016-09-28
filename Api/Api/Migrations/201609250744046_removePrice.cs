namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LioOrders", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LioOrders", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
