using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using W6HBR.Module.SyncfusionDemo.Repository;
using Oqtane.Controllers;
using System.Net;

namespace W6HBR.Module.SyncfusionDemo.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class SyncfusionDemoController : ModuleControllerBase
    {
        private readonly ISyncfusionDemoRepository _SyncfusionDemoRepository;

        public SyncfusionDemoController(ISyncfusionDemoRepository SyncfusionDemoRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _SyncfusionDemoRepository = SyncfusionDemoRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.SyncfusionDemo> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _SyncfusionDemoRepository.GetSyncfusionDemos(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SyncfusionDemo Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.SyncfusionDemo Get(int id)
        {
            Models.SyncfusionDemo SyncfusionDemo = _SyncfusionDemoRepository.GetSyncfusionDemo(id);
            if (SyncfusionDemo != null && IsAuthorizedEntityId(EntityNames.Module, SyncfusionDemo.ModuleId))
            {
                return SyncfusionDemo;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SyncfusionDemo Get Attempt {SyncfusionDemoId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.SyncfusionDemo Post([FromBody] Models.SyncfusionDemo SyncfusionDemo)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, SyncfusionDemo.ModuleId))
            {
                SyncfusionDemo = _SyncfusionDemoRepository.AddSyncfusionDemo(SyncfusionDemo);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "SyncfusionDemo Added {SyncfusionDemo}", SyncfusionDemo);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SyncfusionDemo Post Attempt {SyncfusionDemo}", SyncfusionDemo);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                SyncfusionDemo = null;
            }
            return SyncfusionDemo;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.SyncfusionDemo Put(int id, [FromBody] Models.SyncfusionDemo SyncfusionDemo)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, SyncfusionDemo.ModuleId) && _SyncfusionDemoRepository.GetSyncfusionDemo(SyncfusionDemo.SyncfusionDemoId, false) != null)
            {
                SyncfusionDemo = _SyncfusionDemoRepository.UpdateSyncfusionDemo(SyncfusionDemo);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "SyncfusionDemo Updated {SyncfusionDemo}", SyncfusionDemo);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SyncfusionDemo Put Attempt {SyncfusionDemo}", SyncfusionDemo);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                SyncfusionDemo = null;
            }
            return SyncfusionDemo;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.SyncfusionDemo SyncfusionDemo = _SyncfusionDemoRepository.GetSyncfusionDemo(id);
            if (SyncfusionDemo != null && IsAuthorizedEntityId(EntityNames.Module, SyncfusionDemo.ModuleId))
            {
                _SyncfusionDemoRepository.DeleteSyncfusionDemo(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "SyncfusionDemo Deleted {SyncfusionDemoId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SyncfusionDemo Delete Attempt {SyncfusionDemoId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
