namespace MindfireSolutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        EmployeeImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RolePosition = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ContactNumber = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactTypeValue = c.String(),
                    })
                .PrimaryKey(t => t.ContactTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeContacts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeContacts", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Accesses", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Accesses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeContacts", new[] { "ContactTypeId" });
            DropIndex("dbo.EmployeeContacts", new[] { "EmployeeId" });
            DropIndex("dbo.Accesses", new[] { "RoleId" });
            DropIndex("dbo.Accesses", new[] { "EmployeeId" });
            DropTable("dbo.ContactTypes");
            DropTable("dbo.EmployeeContacts");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Accesses");
        }
    }
}
