using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests;

public class GildedRose_AcceptanceTests
{
    [Fact]
    public void UpdateQuality_Should_ReduceItemSellInTo9WhenInitializedAs10()
    {
        int startSellIn = 10;
        int expectedSellIn = 9;
        Item item = new Item { Name = "Test", Quality = 10, SellIn = startSellIn };
        
        GildedRose sut = new GildedRose(new List<Item> { item });
        sut.UpdateQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
    }

    [Fact]
    public void UpdateQuality_Should_ReduceItemQualityTo9WhenInitializedAs10()
    {
        int startQuality = 10;
        int expectedQuality = 9;
        Item item = new Item { Name = "Test", Quality = startQuality, SellIn = 10 };

        GildedRose sut = new GildedRose(new List<Item> { item });
        sut.UpdateQuality();

        Assert.Equal(expectedQuality, item.SellIn);
    }

}