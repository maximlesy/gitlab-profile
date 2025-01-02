using GildedRoseKata.Strategies.Interfaces;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private IList<Item> items;
    private readonly IItemUpdater itemUpdater;

    public GildedRose(IList<Item> items, IItemUpdater itemUpdater)
    {
        this.items = items;
        this.itemUpdater = itemUpdater;
    }

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            itemUpdater.UpdateItem(item);
        }
    }
}