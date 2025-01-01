using MarketService.Data.Contexts;
using MarketService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketService.Data.Repositories
{
    public class MarketRepository
    {
        private readonly MarketContext _context;

        public MarketRepository(MarketContext context)
        {
            _context = context;
        }

        public Market Add(Market market)
        {
            _context.Markets.Add(market);
            _context.SaveChanges();
            return market;
        }

        public List<Market> GetAll()
        {
            return _context.Markets.AsNoTracking().ToList();
        }

        //public void ChangeMarketState(int id)
        //{
        //    var market = _context.Markets.SingleOrDefault(x=>x.Id == id); 
        //    if(market != null)
        //    {
        //        market.State = true;
        //    }
        //}
    }
}
