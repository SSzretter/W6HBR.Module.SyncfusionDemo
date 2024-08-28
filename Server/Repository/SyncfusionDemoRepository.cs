using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using W6HBR.Module.SyncfusionDemo.Models;

namespace W6HBR.Module.SyncfusionDemo.Repository
{
    public class SyncfusionDemoRepository : ISyncfusionDemoRepository, ITransientService
    {
        private readonly SyncfusionDemoContext _db;

        public SyncfusionDemoRepository(SyncfusionDemoContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.SyncfusionDemo> GetSyncfusionDemos(int ModuleId)
        {
            return _db.SyncfusionDemo.Where(item => item.ModuleId == ModuleId);
        }

        public Models.SyncfusionDemo GetSyncfusionDemo(int SyncfusionDemoId)
        {
            return GetSyncfusionDemo(SyncfusionDemoId, true);
        }

        public Models.SyncfusionDemo GetSyncfusionDemo(int SyncfusionDemoId, bool tracking)
        {
            if (tracking)
            {
                return _db.SyncfusionDemo.Find(SyncfusionDemoId);
            }
            else
            {
                return _db.SyncfusionDemo.AsNoTracking().FirstOrDefault(item => item.SyncfusionDemoId == SyncfusionDemoId);
            }
        }

        public Models.SyncfusionDemo AddSyncfusionDemo(Models.SyncfusionDemo SyncfusionDemo)
        {
            _db.SyncfusionDemo.Add(SyncfusionDemo);
            _db.SaveChanges();
            return SyncfusionDemo;
        }

        public Models.SyncfusionDemo UpdateSyncfusionDemo(Models.SyncfusionDemo SyncfusionDemo)
        {
            _db.Entry(SyncfusionDemo).State = EntityState.Modified;
            _db.SaveChanges();
            return SyncfusionDemo;
        }

        public void DeleteSyncfusionDemo(int SyncfusionDemoId)
        {
            Models.SyncfusionDemo SyncfusionDemo = _db.SyncfusionDemo.Find(SyncfusionDemoId);
            _db.SyncfusionDemo.Remove(SyncfusionDemo);
            _db.SaveChanges();
        }
    }
}
