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
            itemUpdater.UpdateItem(item);
        }
    }
}