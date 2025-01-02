using GildedRoseKata.Strategies;
using GildedRoseKata.Strategies.Interfaces;

namespace GildedRoseKata.Factories
{
    public class UpdateStrategyFactory
    {
        public static IUpdateStrategy GetUpdateStrategy(string itemName)
        {
            return itemName switch
            {
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdateStrategy(),
                "Aged Brie" => new AgedBrieUpdateStrategy(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdateStrategy(),
                _ => new DefaultUpdateStrategy(),
            };
        }
    }
}
