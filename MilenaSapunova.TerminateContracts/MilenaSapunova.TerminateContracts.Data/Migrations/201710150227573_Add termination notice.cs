namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addterminationnotice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TerminationNotices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Company_Id = c.Guid(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Company_Id)
                .Index(t => t.Owner_Id);
            
            AddColumn("dbo.Contracts", "TerminationNotice_Id", c => c.Guid());
            CreateIndex("dbo.Contracts", "TerminationNotice_Id");
            AddForeignKey("dbo.Contracts", "TerminationNotice_Id", "dbo.TerminationNotices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TerminationNotices", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contracts", "TerminationNotice_Id", "dbo.TerminationNotices");
            DropForeignKey("dbo.TerminationNotices", "Company_Id", "dbo.Companies");
            DropIndex("dbo.TerminationNotices", new[] { "Owner_Id" });
            DropIndex("dbo.TerminationNotices", new[] { "Company_Id" });
            DropIndex("dbo.TerminationNotices", new[] { "IsDeleted" });
            DropIndex("dbo.Contracts", new[] { "TerminationNotice_Id" });
            DropColumn("dbo.Contracts", "TerminationNotice_Id");
            DropTable("dbo.TerminationNotices");
        }
    }
}
