using PCDB.Models;
using PCDB.Models.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDB.Interfaces
{
    public interface IComponent
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        string ImageUrl { get; set; }
        Manufacturer Manufacturer { get; set; }
        ComponentType ComponentType { get; }
        string GetComponentTypeLink { get; }
        string GetPrice();
        string GetImagePath();
    }
}
