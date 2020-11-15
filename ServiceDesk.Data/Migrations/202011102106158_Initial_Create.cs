namespace ServiceDesk.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketDepartments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TicketEmployees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        TicketDepartment_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TicketDepartments", t => t.TicketDepartment_id)
                .Index(t => t.TicketDepartment_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        TicketDepartment_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketDepartments", t => t.TicketDepartment_id)
                .Index(t => t.TicketDepartment_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketDepartment_id", "dbo.TicketDepartments");
            DropForeignKey("dbo.TicketEmployees", "TicketDepartment_id", "dbo.TicketDepartments");
            DropIndex("dbo.Tickets", new[] { "TicketDepartment_id" });
            DropIndex("dbo.TicketEmployees", new[] { "TicketDepartment_id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketEmployees");
            DropTable("dbo.TicketDepartments");
        }
    }
}
