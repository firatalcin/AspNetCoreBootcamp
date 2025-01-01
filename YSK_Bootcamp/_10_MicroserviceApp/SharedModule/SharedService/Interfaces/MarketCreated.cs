using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedService.Interfaces
{
    public interface MarketCreated
    {
        public string InventoryId { get; set; }
        public string ItemId { get; set; }
        public int Count { get; set; }
    }
}
