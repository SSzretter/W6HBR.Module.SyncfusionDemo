using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using W6HBR.Module.SyncfusionDemo.Models;

namespace W6HBR.Module.SyncfusionDemo.Services
{
    public class SyncfusionDemoService : ServiceBase, ISyncfusionDemoService, IService
    {
        public SyncfusionDemoService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("SyncfusionDemo");

        public async Task<List<Models.SyncfusionDemo>> GetSyncfusionDemosAsync(int ModuleId)
        {
            List<Models.SyncfusionDemo> SyncfusionDemos = await GetJsonAsync<List<Models.SyncfusionDemo>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.SyncfusionDemo>().ToList());
            return SyncfusionDemos.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.SyncfusionDemo> GetSyncfusionDemoAsync(int SyncfusionDemoId, int ModuleId)
        {
            return await GetJsonAsync<Models.SyncfusionDemo>(CreateAuthorizationPolicyUrl($"{Apiurl}/{SyncfusionDemoId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.SyncfusionDemo> AddSyncfusionDemoAsync(Models.SyncfusionDemo SyncfusionDemo)
        {
            return await PostJsonAsync<Models.SyncfusionDemo>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, SyncfusionDemo.ModuleId), SyncfusionDemo);
        }

        public async Task<Models.SyncfusionDemo> UpdateSyncfusionDemoAsync(Models.SyncfusionDemo SyncfusionDemo)
        {
            return await PutJsonAsync<Models.SyncfusionDemo>(CreateAuthorizationPolicyUrl($"{Apiurl}/{SyncfusionDemo.SyncfusionDemoId}", EntityNames.Module, SyncfusionDemo.ModuleId), SyncfusionDemo);
        }

        public async Task DeleteSyncfusionDemoAsync(int SyncfusionDemoId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{SyncfusionDemoId}", EntityNames.Module, ModuleId));
        }
    }
}
