using GildedRoseKata.Strategies.Interfaces;
using GildedRoseKata.Strategies.Shared;

namespace GildedRoseKata.Strategies
{
    public class ConjuredItemStrategy : UpdateStrategy, IUpdateStrategy
    {
        public void Update(Item item)
        {
            base.DecreaseSellIn(item);
            base.DecreaseQuality(item, 2);
        }
    }
}
