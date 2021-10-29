using System.Data.SqlClient;

namespace WebPhoneBook.DataBaseAccess
{
    public class DataBase
    {
        WebPhoneBookDBEntities dataBase;
        public PhoneBookRepository repository;

        public DataBase()
        {
        }

        public void Connect(string strConnection)
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder(strConnection);
            dataBase = new WebPhoneBookDBEntities(sqlConnectionString.ConnectionString);
            repository = new PhoneBookRepository(dataBase);
            repository.Load();
        }
        public void Connect()
        {
            dataBase = new WebPhoneBookDBEntities();
            repository = new PhoneBookRepository(dataBase);
            repository.Load();
        }

        public void Disconnect()
        {
            dataBase = null;
        }
    }
}
