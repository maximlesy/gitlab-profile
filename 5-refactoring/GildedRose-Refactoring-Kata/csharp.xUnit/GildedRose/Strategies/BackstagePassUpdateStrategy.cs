using GildedRoseKata.Strategies.Interfaces;
using GildedRoseKata.Strategies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class BackstagePassUpdateStrategy : UpdateStrategy, IUpdateStrategy
    {
        public void Update(Item item)
        {
            base.DecreaseSellIn(item);

            IncreaseQuality(item);

            if (item.SellIn < 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
