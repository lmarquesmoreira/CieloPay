namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagemUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Telefone", c => c.String());
            AddColumn("dbo.Users", "ImagemUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ImagemUrl");
            DropColumn("dbo.Users", "Telefone");
        }
    }
}
