using PCDB.Models;
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
        Manufacturer Manufacturer { get; set; }
        ComponentType ComponentType { get; }
        string GetComponentTypeLink { get; }
    }

    public enum ComponentType
    {
        [Description("CPU")]
        CPU,
        [Description("CPU Cooler")]
        CPUCooler,
        [Description("Motherboard")]
        Motherboard,
        [Description("Memory")]
        Memory,
        [Description("Storage")]
        Storage,
        [Description("VideoCard")]
        VideoCard,
        [Description("[No Type]")]
        NoType
    }
}
