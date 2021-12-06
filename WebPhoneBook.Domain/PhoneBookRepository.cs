using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPhoneBook.Domain
{
    public class PhoneBookRepository
    {
        private readonly AppDbContext context;
        public PhoneBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PhoneBook> GetPhoneBooks()
        {
            return context.PhoneBooks;
        }

        public PhoneBook GetPhoneBookById(int id)
        {
            return context.PhoneBooks.Single(x => x.Id == id);
        }

        public int SavePhoneBook(PhoneBook phoneBook)
        {
            if (phoneBook.Id == default)
                context.Entry(phoneBook).State = EntityState.Added;
            else
                context.Entry(phoneBook).State = EntityState.Modified;
            context.SaveChanges();

            return phoneBook.Id;
        }

        public void DeletePhoneBook(PhoneBook phoneBook)
        {
            context.PhoneBooks.Remove(phoneBook);
            context.SaveChanges();
        }
    }
}
