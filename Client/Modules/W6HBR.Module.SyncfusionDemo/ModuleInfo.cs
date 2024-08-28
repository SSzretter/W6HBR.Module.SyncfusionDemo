using Oqtane.Models;
using Oqtane.Modules;

namespace W6HBR.Module.SyncfusionDemo
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "SyncfusionDemo",
            Description = "This module demonstrates the use of the Syncfusion Blazor components.",
            Version = "1.0.0",
            ServerManagerType = "W6HBR.Module.SyncfusionDemo.Manager.SyncfusionDemoManager, W6HBR.Module.SyncfusionDemo.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "W6HBR.Module.SyncfusionDemo.Shared.Oqtane",
            PackageName = "W6HBR.Module.SyncfusionDemo" 
        };
    }
}
