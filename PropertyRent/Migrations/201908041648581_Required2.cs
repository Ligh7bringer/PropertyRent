namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            DropIndex("dbo.EnquiryModels", new[] { "User_Id" });
            AlterColumn("dbo.EnquiryModels", "Property_Id", c => c.Int());
            AlterColumn("dbo.EnquiryModels", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            CreateIndex("dbo.EnquiryModels", "User_Id");
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id");
            AddForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropIndex("dbo.EnquiryModels", new[] { "User_Id" });
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            AlterColumn("dbo.EnquiryModels", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EnquiryModels", "Property_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.EnquiryModels", "User_Id");
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            AddForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id", cascadeDelete: true);
        }
    }
}
