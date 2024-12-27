using InventoryService.Data.Entities;
using MongoDB.Driver;

namespace InventoryService.Data.Repositories
{
    public class ItemInventoryRepository
    {
        private readonly IMongoCollection<ItemInventory> itemInventoryCollection;
        public ItemInventoryRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("InventoryDb");
            itemInventoryCollection = database.GetCollection<ItemInventory>("itemInventories");
        }


        public async Task<List<ItemInventory>?> GetAll()
        {
            var filter = Builders<ItemInventory>.Filter.Empty;

            var result = await itemInventoryCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<ItemInventory?> GetItemInventory(string itemId, string inventoryId)
        {
            var filterI = Builders<ItemInventory>.Filter.Eq(x => x.ItemId, itemId);
            var filterII = Builders<ItemInventory>.Filter.Eq(x => x.InventoryId, inventoryId);


            var filter = Builders<ItemInventory>.Filter.And(filterI, filterII);

            var result = await itemInventoryCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }


        public async Task<ItemInventory> Create(ItemInventory item)
        {
            await itemInventoryCollection.InsertOneAsync(item);
            return item;
        }

        public async Task Update(ItemInventory updatedItem)
        {
            var filter = Builders<ItemInventory>.Filter.Eq(x => x.Id, updatedItem.Id);

            await itemInventoryCollection.FindOneAndReplaceAsync(filter, updatedItem);
        }


        public async Task Remove(string id)
        {
            var filter = Builders<ItemInventory>.Filter.Eq(x => x.Id, id);

            await itemInventoryCollection.DeleteOneAsync(filter);
        }
    }
}
