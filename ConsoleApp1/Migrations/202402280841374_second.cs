namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogInfoes", "EmpEmailId", "dbo.Employees");
            DropIndex("dbo.BlogInfoes", new[] { "EmpEmailId" });
            AlterColumn("dbo.BlogInfoes", "EmpEmailId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogInfoes", "EmpEmailId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BlogInfoes", "EmpEmailId");
            AddForeignKey("dbo.BlogInfoes", "EmpEmailId", "dbo.Employees", "Email_Id", cascadeDelete: true);
        }
    }
}
