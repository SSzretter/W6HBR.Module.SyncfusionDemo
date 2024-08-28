using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace W6HBR.Module.SyncfusionDemo.Models
{
    [Table("W6HBRSyncfusionDemo")]
    public class SyncfusionDemo : IAuditable
    {
        [Key]
        public int SyncfusionDemoId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
