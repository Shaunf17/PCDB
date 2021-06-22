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
    public class Storage : Component
    {
        [DisplayName("Component Type")]
        public override ComponentType ComponentType => ComponentType.Storage;
        public override string GetComponentTypeLink => new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Storage", "Products");
    }
}