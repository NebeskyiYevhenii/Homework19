namespace ServiceDesk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creating_link_between_the_ticket_and_the_department : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Department_id", "dbo.Departments");
            DropIndex("dbo.Tickets", new[] { "Department_id" });
            AlterColumn("dbo.Tickets", "Department_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "Department_id");
            AddForeignKey("dbo.Tickets", "Department_id", "dbo.Departments", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Department_id", "dbo.Departments");
            DropIndex("dbo.Tickets", new[] { "Department_id" });
            AlterColumn("dbo.Tickets", "Department_id", c => c.Int());
            CreateIndex("dbo.Tickets", "Department_id");
            AddForeignKey("dbo.Tickets", "Department_id", "dbo.Departments", "id");
        }
    }
}
