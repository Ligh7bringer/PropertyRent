namespace PropertyRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnquiries2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnquiryModels", "DateSent", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnquiryModels", "DateSent");
        }
    }
}
