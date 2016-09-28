namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itempedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes");
            RenameTable(name: "dbo.DetalhePedidoes", newName: "ItemPedidoes");
            DropIndex("dbo.ItemPedidoes", new[] { "ProdutoId" });
            AddColumn("dbo.ItemPedidoes", "Descricao", c => c.String());
            AddColumn("dbo.ItemPedidoes", "Classificacao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ItemPedidoes", "Nome", c => c.String());
            AddColumn("dbo.ItemPedidoes", "UrlImagem", c => c.String());
            AddColumn("dbo.ItemPedidoes", "Valor", c => c.String());
            DropColumn("dbo.ItemPedidoes", "ProdutoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemPedidoes", "ProdutoId", c => c.Int(nullable: false));
            DropColumn("dbo.ItemPedidoes", "Valor");
            DropColumn("dbo.ItemPedidoes", "UrlImagem");
            DropColumn("dbo.ItemPedidoes", "Nome");
            DropColumn("dbo.ItemPedidoes", "Classificacao");
            DropColumn("dbo.ItemPedidoes", "Descricao");
            CreateIndex("dbo.ItemPedidoes", "ProdutoId");
            AddForeignKey("dbo.DetalhePedidoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ItemPedidoes", newName: "DetalhePedidoes");
        }
    }
}
