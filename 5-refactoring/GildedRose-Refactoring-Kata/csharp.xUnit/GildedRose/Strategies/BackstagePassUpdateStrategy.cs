using GildedRoseKata.Strategies.Interfaces;
using GildedRoseKata.Strategies.Shared;

namespace GildedRoseKata.Strategies
{
    public class BackstagePassUpdateStrategy : UpdateStrategy, IUpdateStrategy
    {
        public void Update(Item item)
        {
            base.DecreaseSellIn(item);

            IncreaseQualityBasedOnConcertProximity(item);
            DropQualityToZeroIfConcertIsOver(item);
        }

        private void IncreaseQualityBasedOnConcertProximity(Item item)
        {
            if(ConcertIsBetween5And10DaysAway(item))
            {
                IncreaseQuality(item, 2);
            }
            else if (ConcertIsLessThan5DaysAway(item))
            {
                IncreaseQuality(item, 3);
            }
        }

        private void DropQualityToZeroIfConcertIsOver(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private bool ConcertIsBetween5And10DaysAway(Item item)
        {
            return item.SellIn < 10 && item.SellIn >= 5;
        }

        private bool ConcertIsLessThan5DaysAway(Item item)
        {
            return item.SellIn < 5;
        }
    }
}
