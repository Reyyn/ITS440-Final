using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace FinalProject {
    /// <summary>
    /// Handles asyncronous connections to the SQLite database.
    /// </summary>
    public class Database {
        readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Represents an asyncronous SQLite database connecion.
        /// </summary>
        /// <param name="dbPath">Path to the SQLite database.</param>
        public Database(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Event>().Wait();
        }

        /// <summary>
        /// Retrieves a list of <c>Event</c>s from the SQLite database.
        /// </summary>
        /// <returns>A list of <c>Events</c>.</returns>
        public Task<List<Event>> GetEventAsync() {
            return _database.Table<Event>().ToListAsync();
        }

        /// <summary>
        /// Saves an <c>Event</c> to the SQLite database.
        /// </summary>
        /// <param name="_event">The <c>Event</c> to write to the database.</param>
        /// <returns>The number of rows inserted.</returns>
        public Task<int> SaveEventAsync(Event _event) {
            return _database.InsertAsync(_event);
        }

        /// <summary>
        /// Removes an <c>Event</c> to the SQLite database by the ID (primary key) of the <c>Event</c>.
        /// </summary>
        /// <param name="_event">The <c>Event</c> to delete from the database.</param>
        /// <returns>The number of rows deleted.</returns>
        public Task<int> RemoveEventAsync(Event _event) {
            return _database.DeleteAsync(_event);
        }
    }
}
