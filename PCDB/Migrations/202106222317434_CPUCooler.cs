namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPUCooler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CPUCooler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturer", t => t.Manufacturer_Id)
                .Index(t => t.Manufacturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CPUCooler", "Manufacturer_Id", "dbo.Manufacturer");
            DropIndex("dbo.CPUCooler", new[] { "Manufacturer_Id" });
            DropTable("dbo.CPUCooler");
        }
    }
}
