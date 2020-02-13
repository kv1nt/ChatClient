using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Repository
{
    public interface IRepository<T>  where T : class  
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Delete(T item);
        void Update(T item);
    }
}
