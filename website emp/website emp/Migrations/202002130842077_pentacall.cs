namespace website_emp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pentacall : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "AssignedById", c => c.Long(nullable: false));
            AddColumn("dbo.Tasks", "AssingedToId", c => c.Long(nullable: false));
            DropColumn("dbo.Tasks", "AssignedBy");
            DropColumn("dbo.Tasks", "AssingedTo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "AssingedTo", c => c.Long(nullable: false));
            AddColumn("dbo.Tasks", "AssignedBy", c => c.Long(nullable: false));
            DropColumn("dbo.Tasks", "AssingedToId");
            DropColumn("dbo.Tasks", "AssignedById");
        }
    }
}
