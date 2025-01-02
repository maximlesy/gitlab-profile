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
                _ => new DefaultUpdateStrategy(),
            };
        }
    }
}
