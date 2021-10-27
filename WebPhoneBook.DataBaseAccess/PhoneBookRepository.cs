using MsgBoxAlertClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace WebPhoneBook.DataBaseAccess
{
    public class PhoneBookRepository : IRepository<PhoneBook>
    {
        private WebPhoneBookDBEntities data;
        public PhoneBookRepository(WebPhoneBookDBEntities dataBase)
        {
            data = dataBase;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    data.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Create(PhoneBook item)
        {
            data.PhoneBookSet.Add(item);
        }

        public void Delete(PhoneBook item)
        {
            data.PhoneBookSet.Remove(item);
        }

        public IEnumerable<PhoneBook> GetDB()
        {
            return data.PhoneBookSet.Local;
        }

        public PhoneBook GetItemByID(long id)
        {
            return data.PhoneBookSet.FirstOrDefault(person => person.Id == id);
        }

        public void Load()
        {
            data.PhoneBookSet.Load();
        }

        public void Save()
        {
            try
            {
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                Alerts.MsgError($"Не удалось сохранить изменения в бд:\n{ex.Message}");
            }
        }

        public void Update(PhoneBook item)
        {
            data.Entry(item).State = EntityState.Modified;
        }
    }
}
