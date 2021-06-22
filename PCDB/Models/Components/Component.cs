using PCDB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PCDB.Models.Components
{
    public class Component : Interfaces.IComponent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }

        public Manufacturer Manufacturer { get; set; }
        [DisplayName("Component Type")]
        public virtual ComponentType ComponentType => ComponentType.NoType;
        public virtual string GetComponentTypeLink => "";
    }
}