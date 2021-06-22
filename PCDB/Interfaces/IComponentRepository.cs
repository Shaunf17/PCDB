using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDB.Interfaces
{
    public interface IComponentRepository<T> where T : class, IComponent
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T component);
        void Update(T component);
        void Delete(int id);
        void Save();
    }
}
