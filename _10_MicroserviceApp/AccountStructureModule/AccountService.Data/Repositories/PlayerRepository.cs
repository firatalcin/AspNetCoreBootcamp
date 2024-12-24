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
        public PlayerRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("AccountStructureDb");

            
        }
    }
}
