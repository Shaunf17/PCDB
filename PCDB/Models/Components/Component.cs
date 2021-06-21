using PCDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCDB.Models.Components
{
    public class Component : IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ComponentType ComponentType { get; set; } = ComponentType.NoType;
        public string GetComponentTypeLink => "";
    }
}