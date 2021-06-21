using PCDB.Interfaces;
using PCDB.Models;
using PCDB.Models.Components;
using PCDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCDB.Repositories
{
    public class ComponentsRepository
    {
        private readonly ApplicationDbContext _context;

        //public ComponentsRepository(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public ComponentsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public ComponentsViewModel GetComponentsViewModel()
        {
            ComponentsViewModel componentsViewModel = new ComponentsViewModel()
            {
                CPU = GetCPU()
            };

            return componentsViewModel;
        }

        public List<CPU> GetCPU()
        {
            return _context.CPU.ToList();
        }

        public CPU FindCPU(int id)
        {
            return _context.CPU.Find(id);
        }

        public List<Memory> GetMemory()
        {
            return _context.Memory.ToList();
        }

        public Memory FindMemory(int id)
        {
            return _context.Memory.Find(id);
        }

        //public List<IComponent> GetComponents(ComponentType componentType)
        //{
        //    return _context.
        //}
    }
}