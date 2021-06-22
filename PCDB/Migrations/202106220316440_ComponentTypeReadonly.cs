namespace PCDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentTypeReadonly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CPU", "ComponentType");
            DropColumn("dbo.Memory", "ComponentType");
            DropColumn("dbo.Storage", "ComponentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Storage", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.Memory", "ComponentType", c => c.Int(nullable: false));
            AddColumn("dbo.CPU", "ComponentType", c => c.Int(nullable: false));
        }
    }
}
