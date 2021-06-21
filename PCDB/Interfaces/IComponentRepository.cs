using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDB.Interfaces
{
    public interface IComponentRepository
    {
        IEnumerable<IComponent> GetAll();
        IComponent GetById(int id);
        void Insert(IComponent component);
        void Update(IComponent component);
        void Delete(int id);
        void Save();
    }
}
