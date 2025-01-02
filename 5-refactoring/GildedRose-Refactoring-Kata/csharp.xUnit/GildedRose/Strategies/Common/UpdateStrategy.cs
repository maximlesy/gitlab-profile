namespace GildedRoseKata.Strategies.Shared
{
    public abstract class UpdateStrategy
    {
        public virtual void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        public virtual void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public virtual void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }


    }
}
