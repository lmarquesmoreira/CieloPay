namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lowercase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_Id" });
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_Id1" });
            AddColumn("dbo.LioOrders", "Payment_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LioOrderItems", "sku", c => c.String());
            AlterColumn("dbo.LioOrders", "number", c => c.String());
            CreateIndex("dbo.LioOrderItems", "LioOrder_id");
            CreateIndex("dbo.LioOrderItems", "LioOrder_id1");
            DropColumn("dbo.LioOrderItems", "Payment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LioOrderItems", "Payment_Id", c => c.Guid(nullable: false));
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_id1" });
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_id" });
            AlterColumn("dbo.LioOrders", "number", c => c.Int(nullable: false));
            AlterColumn("dbo.LioOrderItems", "sku", c => c.Guid(nullable: false));
            DropColumn("dbo.LioOrders", "Payment_Id");
            CreateIndex("dbo.LioOrderItems", "LioOrder_Id1");
            CreateIndex("dbo.LioOrderItems", "LioOrder_Id");
        }
    }
}
