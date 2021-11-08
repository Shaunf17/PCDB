using PCDB.Interfaces;
using PCDB.Models;
using PCDB.Models.Components;
using PCDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDB.Repositories
{
    public class ComponentsRepository<T> : IDisposable, IComponentRepository<T> where T : class, IComponent
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> table = null;

        public ComponentsRepository()
        {
            _context = new ApplicationDbContext();
            table = _context.Set<T>();
        }

        public ComponentsRepository(ApplicationDbContext context)
        {
            _context = context;
            table = context.Set<T>();
        }

        public T Find(int id)
        {
            return table.Find(id);
        }

        public T FindByName(string name)
        {
            return table.Where(n => n.Name == name).FirstOrDefault();
        }

        public void Delete(int id)
        {
            table.Remove(GetById(id));
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T component)
        {
            table.Add(component);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T component)
        {
            table.Attach(component);
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