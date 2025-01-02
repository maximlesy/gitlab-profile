using GildedRoseKata.Factories;

namespace GildedRoseKata.Strategies.Interfaces
{
    public class ItemUpdater : IItemUpdater
    {
        public void UpdateItem(Item item)
        {
            var itemUpdateStrategy = UpdateStrategyFactory.GetUpdateStrategy(item.Name);
            itemUpdateStrategy.Update(item);
        }
    }
}
