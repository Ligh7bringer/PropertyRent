namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            DropIndex("dbo.EnquiryModels", new[] { "User_Id" });
            AlterColumn("dbo.EnquiryModels", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.EnquiryModels", "Property_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.EnquiryModels", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PropertyIdentities", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyIdentities", "Location", c => c.String(nullable: false));
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            CreateIndex("dbo.EnquiryModels", "User_Id");
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropIndex("dbo.EnquiryModels", new[] { "User_Id" });
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            AlterColumn("dbo.PropertyIdentities", "Location", c => c.String());
            AlterColumn("dbo.PropertyIdentities", "Title", c => c.String());
            AlterColumn("dbo.EnquiryModels", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.EnquiryModels", "Property_Id", c => c.Int());
            AlterColumn("dbo.EnquiryModels", "Body", c => c.String());
            CreateIndex("dbo.EnquiryModels", "User_Id");
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            AddForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id");
        }
    }
}
