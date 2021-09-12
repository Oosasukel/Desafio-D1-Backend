using backend.Models;
using backend.Database;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace backend.Services
{
    public class Page<T>
    {
        public long total { get; set; }
        public List<T> items { get; set; }
    }

    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public async Task<Page<User>> GetPageAsync(int page, int limit)
        {
            var itemsToSkip = (page - 1) * limit;
            if (itemsToSkip < 0)
            {
                itemsToSkip = 0;
            }

            var query = _users.Find(user => true);
            var totalTask = query.CountDocumentsAsync();
            var usersTask = query.Skip(itemsToSkip).Limit(limit).ToListAsync();
            await Task.WhenAll(totalTask, usersTask);
            return new Page<User>() { total = totalTask.Result, items = usersTask.Result };
        }

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            user.Id = null;
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User user) =>
            _users.ReplaceOne(item => item.Id == id, user);

        public void Remove(User user) =>
            _users.DeleteOne(item => item.Id == user.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}