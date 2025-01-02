using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            DecreaseSellIn(Items[i]);
            HandleQualityLogic(Items[i]);
        }
    }

    private void HandleQualityLogic(Item item)
    {
        if (item.Name == "Sulfuras, Hand of Ragnaros") return;

        if (item.SellIn < 0)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
            }
            else
            {
                DecreaseQuality(item);
            }
        }

        if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            IncreaseQuality(item);
        }
        else
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
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