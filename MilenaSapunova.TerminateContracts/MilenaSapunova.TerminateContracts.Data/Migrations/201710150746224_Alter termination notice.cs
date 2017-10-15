namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alterterminationnotice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "TerminationNotice_Id", "dbo.TerminationNotices");
            DropIndex("dbo.Contracts", new[] { "TerminationNotice_Id" });
            AddColumn("dbo.TerminationNotices", "IsTemplate", c => c.Boolean(nullable: false));
            AddColumn("dbo.TerminationNotices", "Contract_Id", c => c.Guid());
            CreateIndex("dbo.TerminationNotices", "IsTemplate");
            CreateIndex("dbo.TerminationNotices", "Contract_Id");
            AddForeignKey("dbo.TerminationNotices", "Contract_Id", "dbo.Contracts", "Id");
            DropColumn("dbo.Contracts", "TerminationNotice_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "TerminationNotice_Id", c => c.Guid());
            DropForeignKey("dbo.TerminationNotices", "Contract_Id", "dbo.Contracts");
            DropIndex("dbo.TerminationNotices", new[] { "Contract_Id" });
            DropIndex("dbo.TerminationNotices", new[] { "IsTemplate" });
            DropColumn("dbo.TerminationNotices", "Contract_Id");
            DropColumn("dbo.TerminationNotices", "IsTemplate");
            CreateIndex("dbo.Contracts", "TerminationNotice_Id");
            AddForeignKey("dbo.Contracts", "TerminationNotice_Id", "dbo.TerminationNotices", "Id");
        }
    }
}
