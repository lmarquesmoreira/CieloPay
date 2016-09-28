namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AddressId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AddressId");
        }
    }
}
