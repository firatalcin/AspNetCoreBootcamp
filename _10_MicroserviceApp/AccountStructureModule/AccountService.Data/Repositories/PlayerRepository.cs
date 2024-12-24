using AccountService.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Data.Repositories
{
    public class PlayerRepository
    {
        private readonly IMongoCollection<Player> playerCollection;

        public PlayerRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("AccountStructureDb");

            playerCollection =  database.GetCollection<Player>("players");
        }

        public async Task<Player> Create(Player player)
        {
            await playerCollection.InsertOneAsync(player);

            return player;
        }
    }
}
