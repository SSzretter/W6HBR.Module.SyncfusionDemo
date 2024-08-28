using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using W6HBR.Module.SyncfusionDemo.Repository;

namespace W6HBR.Module.SyncfusionDemo.Manager
{
    public class SyncfusionDemoManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly ISyncfusionDemoRepository _SyncfusionDemoRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public SyncfusionDemoManager(ISyncfusionDemoRepository SyncfusionDemoRepository, IDBContextDependencies DBContextDependencies)
        {
            _SyncfusionDemoRepository = SyncfusionDemoRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new SyncfusionDemoContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new SyncfusionDemoContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.SyncfusionDemo> SyncfusionDemos = _SyncfusionDemoRepository.GetSyncfusionDemos(module.ModuleId).ToList();
            if (SyncfusionDemos != null)
            {
                content = JsonSerializer.Serialize(SyncfusionDemos);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.SyncfusionDemo> SyncfusionDemos = null;
            if (!string.IsNullOrEmpty(content))
            {
                SyncfusionDemos = JsonSerializer.Deserialize<List<Models.SyncfusionDemo>>(content);
            }
            if (SyncfusionDemos != null)
            {
                foreach(var SyncfusionDemo in SyncfusionDemos)
                {
                    _SyncfusionDemoRepository.AddSyncfusionDemo(new Models.SyncfusionDemo { ModuleId = module.ModuleId, Name = SyncfusionDemo.Name });
                }
            }
        }
    }
}
