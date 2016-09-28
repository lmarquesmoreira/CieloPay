namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagemsnoProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "UrlImagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "UrlImagem");
        }
    }
}
