using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using TutorialNET5WebAPI.Models;
using TutorialNET5WebAPI.Repositories.interfaces;

namespace TutorialNET5WebAPI.Repositories
{
    public class MongoDbItemsRepository : IItemRepository
    {
        private const string databaseName = "my_catalog";
        private const string collectionName = "my_items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient client)
        {
            IMongoDatabase db = client.GetDatabase(databaseName);
            itemsCollection = db.GetCollection<Item>(collectionName);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            return await itemsCollection.FindAsync(filter).Result.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.FindAsync(filterBuilder.Empty).Result.ToListAsync();
        }

        public async Task AddItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }

        public async Task RemoveItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }
    }
}
