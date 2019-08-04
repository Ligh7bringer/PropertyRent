namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysUpdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryModels", "PropertyId", "dbo.PropertyIdentities");
            DropForeignKey("dbo.EnquiryModels", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.EnquiryModels", new[] { "UserID" });
            DropIndex("dbo.EnquiryModels", new[] { "PropertyId" });
            DropColumn("dbo.EnquiryModels", "UserID");
            DropColumn("dbo.EnquiryModels", "PropertyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnquiryModels", "PropertyId", c => c.Int(nullable: false));
            AddColumn("dbo.EnquiryModels", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.EnquiryModels", "PropertyId");
            CreateIndex("dbo.EnquiryModels", "UserID");
            AddForeignKey("dbo.EnquiryModels", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EnquiryModels", "PropertyId", "dbo.PropertyIdentities", "Id", cascadeDelete: true);
        }
    }
}
