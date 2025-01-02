using GildedRoseKata.Strategies.Interfaces;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    IItemUpdater itemUpdater;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
        itemUpdater = new ItemUpdater();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            HandleQualityLogic(item);
        }
    }

    private void HandleQualityLogic(Item item)
    {
        itemUpdater.UpdateItem(item);
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }

    private void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }
    }

    private void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }
}