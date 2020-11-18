using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace FinalProject {
    public class Database {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Event>().Wait();
        }

        public Task<List<Event>> GetEventAsync() {
            return _database.Table<Event>().ToListAsync();
        }

        public Task<int> SaveEventAsync(Event _event) {
            return _database.InsertAsync(_event);
        }
    }
}
