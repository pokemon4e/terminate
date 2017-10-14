namespace MilenaSapunova.Terminate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddContract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        ContractNumber = c.String(maxLength: 30),
                        TerminationDate = c.DateTime(nullable: false, storeType: "date"),
                        NotificationDate = c.DateTime(nullable: false, storeType: "date"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.IsDeleted)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Contracts", new[] { "Owner_Id" });
            DropIndex("dbo.Contracts", new[] { "IsDeleted" });
            DropTable("dbo.Contracts");
        }
    }
}
