namespace BTSession03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothers", "ImageUrl", c => c.String());
            AddColumn("dbo.Electronics", "Imageurl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Electronics", "Imageurl");
            DropColumn("dbo.Clothers", "ImageUrl");
        }
    }
}
