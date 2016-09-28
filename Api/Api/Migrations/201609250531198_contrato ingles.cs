namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contratoingles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Name", c => c.String());
            AddColumn("dbo.Produtoes", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Image", c => c.String());
            AddColumn("dbo.Produtoes", "Description", c => c.String());
            AddColumn("dbo.Produtoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Produtoes", "Descricao");
            DropColumn("dbo.Produtoes", "Classificacao");
            DropColumn("dbo.Produtoes", "Nome");
            DropColumn("dbo.Produtoes", "UrlImagem");
            DropColumn("dbo.Produtoes", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Valor", c => c.String());
            AddColumn("dbo.Produtoes", "UrlImagem", c => c.String());
            AddColumn("dbo.Produtoes", "Nome", c => c.String());
            AddColumn("dbo.Produtoes", "Classificacao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Descricao", c => c.String());
            DropColumn("dbo.Produtoes", "Price");
            DropColumn("dbo.Produtoes", "Description");
            DropColumn("dbo.Produtoes", "Image");
            DropColumn("dbo.Produtoes", "Rate");
            DropColumn("dbo.Produtoes", "Name");
        }
    }
}
