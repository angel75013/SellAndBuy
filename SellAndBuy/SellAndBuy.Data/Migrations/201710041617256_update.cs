namespace SellAndBuy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Adds", new[] { "User_Id" });
            DropColumn("dbo.Adds", "UserId");
            RenameColumn(table: "dbo.Adds", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Adds", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Adds", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Adds", new[] { "UserId" });
            AlterColumn("dbo.Adds", "UserId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Adds", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Adds", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Adds", "User_Id");
        }
    }
}
