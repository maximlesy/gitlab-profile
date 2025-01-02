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


        if (item.SellIn < 0 && item.Name != "Aged Brie")
        {
            DecreaseQuality(item);
        }

        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            IncreaseQuality(item);
        }
        else
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Aged Brie")
            {
                DecreaseQuality(item);
            }
        }

        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
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