using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests;

public class GildedRose_AcceptanceTests
{
    [Fact]
    // At the end of each day our system lowers SellIn for every item
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
    // At the end of each day our system lowers Quality for every item
    public void UpdateQuality_Should_ReduceItemQualityTo9WhenInitializedAs10()
    {
        int startQuality = 10;
        int expectedQuality = 9;
        Item item = new Item { Name = "Test", Quality = startQuality, SellIn = 10 };

        GildedRose sut = new GildedRose(new List<Item> { item });
        sut.UpdateQuality();

        Assert.Equal(expectedQuality, item.SellIn);
    }

    [Fact]
    // "The Quality of an item is never negative"
    public void UpdateQuality_ShouldNotMakeQualityLowerThan0()
    {
        int expectedQuality = 0;
        int startQuality = 10;
        int startSellIn = 10;
        Item item = new Item { Name = "Test", Quality = startQuality, SellIn = startSellIn };

        GildedRose sut = new GildedRose(new List<Item> { item });

        for (int i = 0; i < 50; i++)
        {
            sut.UpdateQuality();
        }

        Assert.True(item.Quality >= 0);
    }

    [Fact]
    public void UpdateQuality_IncreasesQualityWhenItemIsAgedBrie()
    {
        int expectedQuality = 20;
        int startQuality = 10;

        int startSellIn = 10;
        int daysThatPass = 10;

        Item item = new Item { Name = "Aged Brie", Quality = startQuality, SellIn = startSellIn };

        GildedRose sut = new GildedRose(new List<Item> { item });

        for (int i = 0; i < daysThatPass; i++)
        {
            sut.UpdateQuality();
        }

        Assert.Equal(expectedQuality, item.Quality);
    }

}