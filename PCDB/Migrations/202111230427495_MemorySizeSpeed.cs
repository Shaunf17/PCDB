namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemorySizeSpeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memory", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Memory", "Speed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memory", "Speed");
            DropColumn("dbo.Memory", "Size");
        }
    }
}
