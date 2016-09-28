namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LioOrders", "PaymentId", c => c.Guid(nullable: false));
            DropColumn("dbo.LioOrders", "Payment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LioOrders", "Payment_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.LioOrders", "PaymentId");
        }
    }
}
