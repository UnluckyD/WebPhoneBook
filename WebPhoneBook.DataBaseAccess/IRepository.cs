using System.Collections.Generic;

namespace WebPhoneBook.DataBaseAccess
{
    interface IRepository<T>
    {
        IEnumerable<T> GetDB();
        T GetItemByID(long id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Load();
        void Save();
    }
}
