namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnquiries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnquiryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnquiryModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EnquiryModels", new[] { "User_Id" });
            DropTable("dbo.EnquiryModels");
        }
    }
}
