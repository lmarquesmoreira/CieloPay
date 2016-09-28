namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.AvaiableItems");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.DetalhePedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.PedidoId })
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.AvaiableItems");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.OrderId });
            
            CreateTable(
                "dbo.AvaiableItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.DetalhePedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Users");
            DropIndex("dbo.DetalhePedidoes", new[] { "ProdutoId" });
            DropIndex("dbo.DetalhePedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.DetalhePedidoes");
            DropTable("dbo.Pedidoes");
            CreateIndex("dbo.OrderItems", "ItemId");
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "ItemId", "dbo.AvaiableItems", "Id", cascadeDelete: true);
        }
    }
}
