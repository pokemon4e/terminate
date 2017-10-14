namespace MilenaSapunova.Terminate.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<TerminateConracts.Data.Models.MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TerminateConracts.Data.Models.MsSqlDbContext context)
        {

        }
    }
}
