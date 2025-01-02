using GildedRoseKata.Strategies.Interfaces;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private IList<Item> items;
    private IItemUpdater itemUpdater;

    public GildedRose(IList<Item> items)
    {
        this.items = items;
        itemUpdater = new ItemUpdater();
    }

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            itemUpdater.UpdateItem(item);
        }
    }
}