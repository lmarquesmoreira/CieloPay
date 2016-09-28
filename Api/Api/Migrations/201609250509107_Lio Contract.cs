namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LioContract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LioOrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        sku = c.Guid(nullable: false),
                        Payment_Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Unit_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        unit_of_measure = c.String(),
                        details = c.String(),
                        created_at = c.String(),
                        updated_at = c.String(),
                        OrderId = c.Guid(nullable: false),
                        LioOrder_Id = c.Guid(),
                        LioOrder_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LioOrders", t => t.LioOrder_Id)
                .ForeignKey("dbo.LioOrders", t => t.LioOrder_Id1)
                .ForeignKey("dbo.LioOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.LioOrder_Id)
                .Index(t => t.LioOrder_Id1);
            
            CreateTable(
                "dbo.LioOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Reference = c.String(),
                        Status = c.String(),
                        Created_At = c.String(),
                        Updated_At = c.String(),
                        Notes = c.String(),
                        Price = c.Int(nullable: false),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LioOrderItems", "OrderId", "dbo.LioOrders");
            DropForeignKey("dbo.LioOrders", "UserId", "dbo.Users");
            DropForeignKey("dbo.LioOrderItems", "LioOrder_Id1", "dbo.LioOrders");
            DropForeignKey("dbo.LioOrderItems", "LioOrder_Id", "dbo.LioOrders");
            DropIndex("dbo.LioOrders", new[] { "UserId" });
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_Id1" });
            DropIndex("dbo.LioOrderItems", new[] { "LioOrder_Id" });
            DropIndex("dbo.LioOrderItems", new[] { "OrderId" });
            DropTable("dbo.LioOrders");
            DropTable("dbo.LioOrderItems");
        }
    }
}
