using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Repository
{
    public interface IRepository<T>  where T : class  
    {
        bool Create(T item);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByUserId(string id);
        T Get(Guid id);
        void Delete(T item);
        void Update(T item);
    }
}
