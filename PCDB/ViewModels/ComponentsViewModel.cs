using PCDB.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCDB.ViewModels
{
    public class ComponentsViewModel
    {
        public List<CPU> CPU { get; set; }
        public List<Memory> Memory { get; set; }
        public List<Storage> Storage { get; set; }
    }

    public class ComponentCreateViewModel
    {
        public ComponentType ComponentType { get; set; }
    }
}