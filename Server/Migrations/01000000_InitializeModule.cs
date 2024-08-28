using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using W6HBR.Module.SyncfusionDemo.Migrations.EntityBuilders;
using W6HBR.Module.SyncfusionDemo.Repository;

namespace W6HBR.Module.SyncfusionDemo.Migrations
{
    [DbContext(typeof(SyncfusionDemoContext))]
    [Migration("W6HBR.Module.SyncfusionDemo.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new SyncfusionDemoEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new SyncfusionDemoEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
