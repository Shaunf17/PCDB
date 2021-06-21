namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentTypeSet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CPU", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.Memory", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.Storage", "ComponentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Storage", "ComponentType");
            DropColumn("dbo.Memory", "ComponentType");
            DropColumn("dbo.CPU", "ComponentType");
        }
    }
}
