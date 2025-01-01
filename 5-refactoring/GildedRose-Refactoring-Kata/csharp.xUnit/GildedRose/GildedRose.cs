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

            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    DecreaseQuality(Items[i]);
                }
            }
            else
            {
                IncreaseQuality(Items[i]);
                HandleQualityLogic(Items[i]);
            }

             

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            DecreaseQuality(Items[i]);
                        }
                    }
                    else
                    {
                        // Quality drops to 0 after the concert
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    IncreaseQuality(Items[i]);
                }
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

    private void HandleQualityLogic(Item item)
    {
        
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
        }
    }
}