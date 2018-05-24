using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Repository
{
    public interface IContactCollGenericRepository<T>
    {
        Task<List<T>> GetAll(int entityID);
        Task<T> GetByID(int itemCollEntityID);
        Task<int> Save(T itemCollEntity);
        Task<int> Delete(int itemCollEntityID);
        
    }
}
