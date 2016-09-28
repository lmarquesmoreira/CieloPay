namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Descricao", c => c.String());
            AddColumn("dbo.Produtoes", "Classificacao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Classificacao");
            DropColumn("dbo.Produtoes", "Descricao");
        }
    }
}
