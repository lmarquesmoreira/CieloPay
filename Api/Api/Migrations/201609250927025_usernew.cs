namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernew : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AddressId", c => c.Int(nullable: false));
        }
    }
}
