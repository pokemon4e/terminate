namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 17),
                        Email = c.String(nullable: false, maxLength: 254),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", new[] { "IsDeleted" });
            DropTable("dbo.Companies");
        }
    }
}
