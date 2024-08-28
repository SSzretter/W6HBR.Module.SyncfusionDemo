using System.Collections.Generic;
using W6HBR.Module.SyncfusionDemo.Models;

namespace W6HBR.Module.SyncfusionDemo.Repository
{
    public interface ISyncfusionDemoRepository
    {
        IEnumerable<Models.SyncfusionDemo> GetSyncfusionDemos(int ModuleId);
        Models.SyncfusionDemo GetSyncfusionDemo(int SyncfusionDemoId);
        Models.SyncfusionDemo GetSyncfusionDemo(int SyncfusionDemoId, bool tracking);
        Models.SyncfusionDemo AddSyncfusionDemo(Models.SyncfusionDemo SyncfusionDemo);
        Models.SyncfusionDemo UpdateSyncfusionDemo(Models.SyncfusionDemo SyncfusionDemo);
        void DeleteSyncfusionDemo(int SyncfusionDemoId);
    }
}
