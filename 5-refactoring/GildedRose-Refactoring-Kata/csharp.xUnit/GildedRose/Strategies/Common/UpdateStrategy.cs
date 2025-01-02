using System;

namespace GildedRoseKata.Strategies.Shared
{
    public abstract class UpdateStrategy
    {
        public virtual void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        public virtual void IncreaseQuality(Item item, int increment = 1)
        {           
            int updatedQuality = item.Quality + increment;

            if (updatedQuality < 50)
            {
                item.Quality = updatedQuality;
            }
            else 
            { 
                item.Quality = 50; 
            }
        }

        public virtual void DecreaseQuality(Item item, int decrement = 1)
        {
            int updatedQuality = item.Quality - decrement;

            if (updatedQuality > 0)
            {
                item.Quality = updatedQuality;
            }
            else
            {
                item.Quality = 0;
            }

            DecreaseQualityExtraIfSellInHasPassed(item);
        }

        private void DecreaseQualityExtraIfSellInHasPassed(Item item)
        {
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
