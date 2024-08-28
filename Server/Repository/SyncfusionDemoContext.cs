using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace W6HBR.Module.SyncfusionDemo.Repository
{
    public class SyncfusionDemoContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.SyncfusionDemo> SyncfusionDemo { get; set; }

        public SyncfusionDemoContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
