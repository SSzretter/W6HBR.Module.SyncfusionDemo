using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using System.Collections.Generic;

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
            PackageName = "W6HBR.Module.SyncfusionDemo",
            Resources = new List<Resource>()
            {
                new Resource { ResourceType = ResourceType.Script, Url = "_content/Syncfusion.Blazor/styles/bootstrap5.css" },
                new Resource { ResourceType = ResourceType.Script, Url = "_content/Syncfusion.Blazor/styles/material-dark.css" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url =  "~/Module.css" },
                new Resource { ResourceType = ResourceType.Script, Url =  "~/Module.js" }
            }
        };
    }
}
