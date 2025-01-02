using GildedRoseKata.Strategies;
using GildedRoseKata.Strategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories
{
    public class UpdateStrategyFactory
    {
        public static IUpdateStrategy GetUpdateStrategy(string itemName)
        {
            return itemName switch
            {
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdateStrategy(),
                _ => null,
            };
        }
    }
}
