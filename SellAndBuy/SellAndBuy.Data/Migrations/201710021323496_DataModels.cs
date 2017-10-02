namespace SellAndBuy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        PhotosPath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        Category_Id = c.Guid(),
                        City_Id = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Category_Id)
                .Index(t => t.City_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategorieName = c.Int(nullable: false),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "TelephoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "City_Id", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "City_Id");
            AddForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Adds", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Adds", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Adds", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "City_Id" });
            DropIndex("dbo.Adds", new[] { "User_Id" });
            DropIndex("dbo.Adds", new[] { "City_Id" });
            DropIndex("dbo.Adds", new[] { "Category_Id" });
            DropIndex("dbo.Adds", new[] { "IsDeleted" });
            DropIndex("dbo.AspNetUsers", new[] { "City_Id" });
            DropColumn("dbo.AspNetUsers", "City_Id");
            DropColumn("dbo.AspNetUsers", "TelephoneNumber");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
            DropTable("dbo.Adds");
        }
    }
}
