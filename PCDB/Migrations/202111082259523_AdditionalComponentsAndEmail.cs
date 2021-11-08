namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalComponentsAndEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Component", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Motherboard",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Component", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PowerSupply",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Component", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.VideoCard",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Component", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoCard", "Id", "dbo.Component");
            DropForeignKey("dbo.PowerSupply", "Id", "dbo.Component");
            DropForeignKey("dbo.Motherboard", "Id", "dbo.Component");
            DropForeignKey("dbo.Case", "Id", "dbo.Component");
            DropIndex("dbo.VideoCard", new[] { "Id" });
            DropIndex("dbo.PowerSupply", new[] { "Id" });
            DropIndex("dbo.Motherboard", new[] { "Id" });
            DropIndex("dbo.Case", new[] { "Id" });
            DropTable("dbo.VideoCard");
            DropTable("dbo.PowerSupply");
            DropTable("dbo.Motherboard");
            DropTable("dbo.Case");
        }
    }
}
