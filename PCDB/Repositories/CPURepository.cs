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
    public class CPURepository : IComponentRepository
    {
        private ApplicationDbContext _context;

        public CPURepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Delete(int id)
        {
            _context.CPU.Remove((CPU)GetById(id));
        }

        public IEnumerable<IComponent> GetAll()
        {
            return _context.CPU;
        }

        public IComponent GetById(int id)
        {
            return _context.CPU.Find(id);
        }

        public void Insert(IComponent component)
        {
            _context.CPU.Add((CPU)component);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(IComponent component)
        {
            _context.Entry(component).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}