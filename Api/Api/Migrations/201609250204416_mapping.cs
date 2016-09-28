namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Users");
            DropPrimaryKey("dbo.DetalhePedidoes");
            AddPrimaryKey("dbo.DetalhePedidoes", "Id");
            AddForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Users");
            DropForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes");
            DropPrimaryKey("dbo.DetalhePedidoes");
            AddPrimaryKey("dbo.DetalhePedidoes", new[] { "Id", "PedidoId" });
            AddForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Users", "Id");
            AddForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes", "Id");
        }
    }
}
