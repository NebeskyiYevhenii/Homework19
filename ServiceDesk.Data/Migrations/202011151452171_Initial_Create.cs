namespace ServiceDesk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Department_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.Department_id)
                .Index(t => t.Department_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Department_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.Department_id)
                .Index(t => t.Department_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Department_id", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Department_id", "dbo.Departments");
            DropIndex("dbo.Tickets", new[] { "Department_id" });
            DropIndex("dbo.Employees", new[] { "Department_id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
