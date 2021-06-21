using PCDB.Interfaces;
using PCDB.Models;
using PCDB.Models.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDB.Repositories
{
    public class MemoryRepository : IComponentRepository
    {
        ApplicationDbContext _context;

        public MemoryRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Delete(int id)
        {
            _context.Memory.Remove((Memory)GetById(id));
        }

        public IEnumerable<IComponent> GetAll()
        {
            return _context.Memory;
        }

        public IComponent GetById(int id)
        {
            return _context.Memory.Find(id);
        }

        public void Insert(IComponent component)
        {
            _context.Memory.Add((Memory)component);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(IComponent component)
        {
            _context.Entry(component).State = EntityState.Modified;
        }
    }
}