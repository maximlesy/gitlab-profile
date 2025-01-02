namespace GildedRoseKata.Strategies.Shared
{
    public abstract class UpdateStrategy
    {
        public virtual void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
