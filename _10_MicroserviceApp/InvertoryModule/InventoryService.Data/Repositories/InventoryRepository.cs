using InventoryService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Data.Repositories
{
    public class InventoryRepository
    {
        private readonly IMongoCollection<Inventory> inventoryCollection;
        public InventoryRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventoryDb");
            inventoryCollection = database.GetCollection<Inventory>("inventories");
        }


        public async Task<List<Inventory>?> GetAll()
        {
            var filter = Builders<Inventory>.Filter.Empty;

            var result = await inventoryCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<Inventory?> GetById(string id)
        {
            var filter = Builders<Inventory>.Filter.Eq(x => x.Id, id);

            var result = await inventoryCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }


        public async Task<Inventory> Create(Inventory item)
        {
            await inventoryCollection.InsertOneAsync(item);
            return item;
        }

        public async Task Update(Inventory updatedItem)
        {
            var filter = Builders<Inventory>.Filter.Eq(x => x.Id, updatedItem.Id);

            await inventoryCollection.FindOneAndReplaceAsync(filter, updatedItem);
        }


        public async Task Remove(string id)
        {
            var filter = Builders<Inventory>.Filter.Eq(x => x.Id, id);

            await inventoryCollection.DeleteOneAsync(filter);
        }
    }
}
