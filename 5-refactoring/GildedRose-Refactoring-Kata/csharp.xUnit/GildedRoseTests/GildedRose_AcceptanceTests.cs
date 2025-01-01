using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests;

public class GildedRose_AcceptanceTests
{
    [Fact] // At the end of each day our system lowers SellIn for every item
    public void UpdateQuality_ShouldReduceItemSellInTo9_WhenInitializedAs10()
    {
        // arrange
        int startSellIn = 10;
        int expectedSellIn = 9;
        Item item = CreateItem("Test", 10, startSellIn);
        GildedRose sut = CreateGildedRose(item);

        // act
        sut.UpdateQuality();

        // assert
        Assert.Equal(expectedSellIn, item.SellIn);
    }

    [Fact] // At the end of each day our system lowers Quality for every item
    public void UpdateQuality_ShouldReduceItemQualityTo9_WhenInitializedAs10()
    {
        // arrange
        int startQuality = 10;
        int expectedQuality = 9;
        Item item = CreateItem("Test", startQuality, 10);
        GildedRose sut = CreateGildedRose(item);

        // act
        sut.UpdateQuality();

        // assert
        Assert.Equal(expectedQuality, item.SellIn);
    }

    [Fact] // The Quality of an item is never negative
    public void UpdateQuality_Should_NotMakeQualityLowerThan0()
    {
        // arrange
        int expectedQuality = 0;
        int startQuality = 10;
        int startSellIn = 10;
        int daysThatPass = 50;
        Item item = CreateItem("Test", startQuality, startSellIn);
        GildedRose sut = CreateGildedRose(item);

        // act
        CycleDays(daysThatPass, sut);

        // assert
        Assert.True(item.Quality >= 0);
    }

    [Fact] // The Quality of an item is never more than 50
    public void UpdateQuality_Should_NeverMakeQualityHigherThan50()
    {
        // arrange
        int expectedQuality = 50;
        int startQuality = 1;
        int startSellIn = 1;
        int daysThatPass = 100;
        Item maxQualityItem = CreateItem("Aged Brie", startQuality, startSellIn);
        GildedRose sut = CreateGildedRose(maxQualityItem);

        // act
        CycleDays(daysThatPass, sut);

        // assert
        Assert.Equal(expectedQuality, maxQualityItem.Quality);
    }

    [Fact] // "Aged Brie" actually increases in Quality the older it gets
    public void UpdateQuality_ShouldIncreaseQuality_WhenItemIsAgedBrie()
    {
        // arrange
        int expectedQuality = 20;
        int startQuality = 10;

        int startSellIn = 10;
        int daysThatPass = 10;

        Item agedBrie = CreateItem("Aged Brie", startQuality, startSellIn);
        GildedRose sut = CreateGildedRose(agedBrie);

        // act
        CycleDays(daysThatPass, sut);

        //assert
        Assert.Equal(expectedQuality, agedBrie.Quality);
    }

    [Fact] // Once the sell by date has passed, Quality degrades twice as fast
    public void UpdateQuality_ShouldDecreacesQuality2x_WhenSellInDateHasPassed()
    {
        // arrange
        int sellIn = 1;
        int startQuality = 10;
        int daysThatPass = 4;
        int expectedQuality = 3;
        Item item = CreateItem("Test", startQuality, sellIn);
        GildedRose sut = CreateGildedRose(item);

        // act
        CycleDays(daysThatPass, sut);

        // assert
        // expected: 10 - 1 - 2 - 2 - 2 = 3;
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact] // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    public void UpdateQuality_ShouldNeverDecreaseQuality_WhenItemIsLengendary()
    {
        // Arrange
        int daysThatPass = 50,
            startQuality = 50,
            expectedQuality = 50;

        Item legandaryItem = CreateItem("Sulfuras, Hand of Ragnaros", daysThatPass, startQuality);
        GildedRose sut = CreateGildedRose(legandaryItem);

        // Act
        CycleDays(daysThatPass, sut);

        // Assert
        Assert.Equal(expectedQuality, legandaryItem.Quality);
    }

    private static GildedRose CreateGildedRose(params Item[] items)
    {
        return new GildedRose(CreateItemList(items));
    }

    private static List<Item> CreateItemList(params Item[] items)
    {
        return new List<Item>(items);
    }

    private static Item CreateItem(string name, int quality, int sellIn)
    {
        return new Item { Name = name, Quality = quality, SellIn = sellIn };
    }

    private static void CycleDays(int daysThatPass, GildedRose sut)
    {
        for (int i = 0; i < daysThatPass; i++)
        {
            sut.UpdateQuality();
        }
    }
}