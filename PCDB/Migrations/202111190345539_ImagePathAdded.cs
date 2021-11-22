namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Component", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Component", "ImageUrl");
        }
    }
}
