namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnquiries3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryModels", "Property_Id", c => c.Int());
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            DropColumn("dbo.EnquiryModels", "Property_Id");
        }
    }
}
