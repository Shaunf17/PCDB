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
    public class Memory : Component
    {
        public int Size { get; set; }
        public int Speed { get; set; }

        [DisplayName("Component Type")]
        public override ComponentType ComponentType => ComponentType.Memory;
        public override string GetComponentTypeLink => new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Memory", "Components");
    }
}