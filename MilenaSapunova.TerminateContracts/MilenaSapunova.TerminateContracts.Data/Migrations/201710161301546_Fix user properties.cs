namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixuserproperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime(nullable: false));
        }
    }
}
