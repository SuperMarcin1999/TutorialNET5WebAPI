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
            //return await itemsCollection.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Task AddItemAsync(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(i => i.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public Task RemoveItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(i => i.Id, id);
            itemsCollection.DeleteOne(filter);
        }
    }
}
