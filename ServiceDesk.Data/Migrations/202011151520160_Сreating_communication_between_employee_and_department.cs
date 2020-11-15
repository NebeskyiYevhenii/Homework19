namespace ServiceDesk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Сreating_communication_between_employee_and_department : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_id" });
            AlterColumn("dbo.Employees", "Department_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Department_id");
            AddForeignKey("dbo.Employees", "Department_id", "dbo.Departments", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_id" });
            AlterColumn("dbo.Employees", "Department_id", c => c.Int());
            CreateIndex("dbo.Employees", "Department_id");
            AddForeignKey("dbo.Employees", "Department_id", "dbo.Departments", "id");
        }
    }
}
