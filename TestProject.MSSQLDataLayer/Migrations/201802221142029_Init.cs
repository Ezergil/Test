namespace TestProject.MSSQLDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupRelations",
                c => new
                    {
                        ChildGroupId = c.Int(nullable: false),
                        ParentGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildGroupId, t.ParentGroupId })
                .ForeignKey("dbo.Groups", t => t.ChildGroupId)
                .ForeignKey("dbo.Groups", t => t.ParentGroupId)
                .Index(t => t.ChildGroupId)
                .Index(t => t.ParentGroupId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropForeignKey("dbo.GroupRelations", "ParentGroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupRelations", "ChildGroupId", "dbo.Groups");
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.GroupRelations", new[] { "ParentGroupId" });
            DropIndex("dbo.GroupRelations", new[] { "ChildGroupId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.GroupRelations");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
