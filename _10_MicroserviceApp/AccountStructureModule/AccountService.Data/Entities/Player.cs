using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Data.Entities
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; }
    }
}
