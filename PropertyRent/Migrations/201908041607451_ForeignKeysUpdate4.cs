namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysUpdate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryModels", "Property_Id", c => c.Int());
            AddColumn("dbo.EnquiryModels", "User_Id", c => c.String(maxLength: 128));
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
            DropColumn("dbo.EnquiryModels", "User_Id");
            DropColumn("dbo.EnquiryModels", "Property_Id");
        }
    }
}
