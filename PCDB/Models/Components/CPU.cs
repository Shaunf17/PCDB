using PCDB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Models.Components
{
    [DisplayName("CPU")]
    public class CPU : Component
    {
        [DisplayName("Component Type")]
        public override ComponentType ComponentType => ComponentType.CPU;
        public override string GetComponentTypeLink => new UrlHelper(HttpContext.Current.Request.RequestContext).Action("CPU", "Components");

        [DisplayName("Core Count")]
        public int CoreCount { get; set; }
        [DisplayName("Core Clock")]
        public string CoreClock { get; set; } 
    }
}