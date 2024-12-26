using MongoDB.Bson.Serialization.Attributes;

namespace InventoryService.Data.Entities
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string PlayerId { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; } = null!;


    }
}
