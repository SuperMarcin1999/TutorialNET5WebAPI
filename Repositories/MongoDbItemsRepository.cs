using System;
using System.Collections.Generic;
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

        public MongoDbItemsRepository(IMongoClient client)
        {
            IMongoDatabase db = client.GetDatabase(databaseName);
            itemsCollection = db.GetCollection<Item>(collectionName);
        }

        public Item GetItem(Guid id)
        {
            return null;
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item, Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
