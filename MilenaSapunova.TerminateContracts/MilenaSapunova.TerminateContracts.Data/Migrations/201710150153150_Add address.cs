namespace MilenaSapunova.TerminateContracts.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Addaddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Town_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id, cascadeDelete: true)
                .Index(t => t.IsDeleted)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        PostalCode = c.String(maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Contracts", "Company_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Companies", "Address_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Contracts", "Company_Id");
            CreateIndex("dbo.Companies", "Address_Id");
            AddForeignKey("dbo.Companies", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Countries", new[] { "IsDeleted" });
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropIndex("dbo.Towns", new[] { "IsDeleted" });
            DropIndex("dbo.Addresses", new[] { "Town_Id" });
            DropIndex("dbo.Addresses", new[] { "IsDeleted" });
            DropIndex("dbo.Companies", new[] { "Address_Id" });
            DropIndex("dbo.Contracts", new[] { "Company_Id" });
            DropColumn("dbo.Companies", "Address_Id");
            DropColumn("dbo.Contracts", "Company_Id");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Addresses");
        }
    }
}
