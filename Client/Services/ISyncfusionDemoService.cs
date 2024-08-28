using System.Collections.Generic;
using System.Threading.Tasks;
using W6HBR.Module.SyncfusionDemo.Models;

namespace W6HBR.Module.SyncfusionDemo.Services
{
    public interface ISyncfusionDemoService 
    {
        Task<List<Models.SyncfusionDemo>> GetSyncfusionDemosAsync(int ModuleId);

        Task<Models.SyncfusionDemo> GetSyncfusionDemoAsync(int SyncfusionDemoId, int ModuleId);

        Task<Models.SyncfusionDemo> AddSyncfusionDemoAsync(Models.SyncfusionDemo SyncfusionDemo);

        Task<Models.SyncfusionDemo> UpdateSyncfusionDemoAsync(Models.SyncfusionDemo SyncfusionDemo);

        Task DeleteSyncfusionDemoAsync(int SyncfusionDemoId, int ModuleId);
    }
}
