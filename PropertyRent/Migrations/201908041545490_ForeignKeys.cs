namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities");
            DropIndex("dbo.EnquiryModels", new[] { "Property_Id" });
            RenameColumn(table: "dbo.EnquiryModels", name: "Property_Id", newName: "PropertyId");
            RenameColumn(table: "dbo.EnquiryModels", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.EnquiryModels", name: "IX_User_Id", newName: "IX_UserID");
            AlterColumn("dbo.EnquiryModels", "PropertyId", c => c.Int(nullable: false));
            CreateIndex("dbo.EnquiryModels", "PropertyId");
            AddForeignKey("dbo.EnquiryModels", "PropertyId", "dbo.PropertyIdentities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryModels", "PropertyId", "dbo.PropertyIdentities");
            DropIndex("dbo.EnquiryModels", new[] { "PropertyId" });
            AlterColumn("dbo.EnquiryModels", "PropertyId", c => c.Int());
            RenameIndex(table: "dbo.EnquiryModels", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.EnquiryModels", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.EnquiryModels", name: "PropertyId", newName: "Property_Id");
            CreateIndex("dbo.EnquiryModels", "Property_Id");
            AddForeignKey("dbo.EnquiryModels", "Property_Id", "dbo.PropertyIdentities", "Id");
        }
    }
}
