using GildedRoseKata.Strategies.Interfaces;
using GildedRoseKata.Strategies.Shared;

namespace GildedRoseKata.Strategies
{
    public class SulfurasUpdateStrategy : UpdateStrategy, IUpdateStrategy
    {
        public void Update(Item item)
        {
            base.DecreaseSellIn(item);
        }
    }
}
