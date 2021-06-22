namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufacturerClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CPU", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.CPU", "CoreCount", c => c.Int(nullable: false));
            AddColumn("dbo.CPU", "CoreClock", c => c.String());
            AddColumn("dbo.CPU", "Manufacturer_Id", c => c.Int());
            AddColumn("dbo.Memory", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.Memory", "Manufacturer_Id", c => c.Int());
            AddColumn("dbo.Storage", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.Storage", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.CPU", "Manufacturer_Id");
            CreateIndex("dbo.Memory", "Manufacturer_Id");
            CreateIndex("dbo.Storage", "Manufacturer_Id");
            AddForeignKey("dbo.CPU", "Manufacturer_Id", "dbo.Manufacturer", "Id");
            AddForeignKey("dbo.Memory", "Manufacturer_Id", "dbo.Manufacturer", "Id");
            AddForeignKey("dbo.Storage", "Manufacturer_Id", "dbo.Manufacturer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storage", "Manufacturer_Id", "dbo.Manufacturer");
            DropForeignKey("dbo.Memory", "Manufacturer_Id", "dbo.Manufacturer");
            DropForeignKey("dbo.CPU", "Manufacturer_Id", "dbo.Manufacturer");
            DropIndex("dbo.Storage", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Memory", new[] { "Manufacturer_Id" });
            DropIndex("dbo.CPU", new[] { "Manufacturer_Id" });
            DropColumn("dbo.Storage", "Manufacturer_Id");
            DropColumn("dbo.Storage", "ComponentType");
            DropColumn("dbo.Memory", "Manufacturer_Id");
            DropColumn("dbo.Memory", "ComponentType");
            DropColumn("dbo.CPU", "Manufacturer_Id");
            DropColumn("dbo.CPU", "CoreClock");
            DropColumn("dbo.CPU", "CoreCount");
            DropColumn("dbo.CPU", "ComponentType");
            DropTable("dbo.Manufacturer");
        }
    }
}
