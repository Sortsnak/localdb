using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using localdb.Models;
using SQLite;

namespace localdb
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Credentials>().Wait();
           
            
        }

        // Show the registers
        public Task<List<Credentials>> GetPeopleAsync()
        {
            return _database.Table<Credentials>().ToListAsync();
        }

        // Save registers
        public Task<int> SavePersonAsync(Credentials credential)
        {
            return _database.InsertAsync(credential);
        }

        // Delete registers
        public Task<int> DeletePersonAsync(Credentials credential)
        {
            return _database.DeleteAsync(credential);
        }

        // Update registers
        public Task<int> UpdatePersonAsync(Credentials credential)
        {
            return _database.UpdateAsync(credential);
        }


    }
}
