using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace W6HBR.Module.SyncfusionDemo.Migrations.EntityBuilders
{
    public class SyncfusionDemoEntityBuilder : AuditableBaseEntityBuilder<SyncfusionDemoEntityBuilder>
    {
        private const string _entityTableName = "W6HBRSyncfusionDemo";
        private readonly PrimaryKey<SyncfusionDemoEntityBuilder> _primaryKey = new("PK_W6HBRSyncfusionDemo", x => x.SyncfusionDemoId);
        private readonly ForeignKey<SyncfusionDemoEntityBuilder> _moduleForeignKey = new("FK_W6HBRSyncfusionDemo_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public SyncfusionDemoEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override SyncfusionDemoEntityBuilder BuildTable(ColumnsBuilder table)
        {
            SyncfusionDemoId = AddAutoIncrementColumn(table,"SyncfusionDemoId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> SyncfusionDemoId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
