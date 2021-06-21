using PCDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Models.Components
{
    public class CPU : IComponent
    {
        // Generic Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ComponentType ComponentType { get; set; } = ComponentType.CPU;
        public string GetComponentTypeLink => new UrlHelper(HttpContext.Current.Request.RequestContext).Action("CPU", "Products");

        // Specifications
        //public 
    }
}