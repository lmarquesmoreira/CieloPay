namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LioOrderItems", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LioOrderItems", "ImageUrl");
        }
    }
}
