namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
            CreateIndex("dbo.AspNetUsers", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropColumn("dbo.AspNetUsers", "ModifiedOn");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "DeletedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
        }
    }
}
