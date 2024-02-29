namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Email_Id = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email_Id);
            
            CreateTable(
                "dbo.BlogInfoes",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        BlogUlrb = c.String(nullable: false),
                        EmpEmailId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Employees", t => t.EmpEmailId, cascadeDelete: true)
                .Index(t => t.EmpEmailId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Email_Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        DataofJoining = c.DateTime(nullable: false),
                        PassCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogInfoes", "EmpEmailId", "dbo.Employees");
            DropIndex("dbo.BlogInfoes", new[] { "EmpEmailId" });
            DropTable("dbo.Employees");
            DropTable("dbo.BlogInfoes");
            DropTable("dbo.Admins");
        }
    }
}
