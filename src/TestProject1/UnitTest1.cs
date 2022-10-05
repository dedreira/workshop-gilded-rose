using GildedRose;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace TestProject1
{
    public class UnitTest1
    {
        private IList<Item> Items;
        public UnitTest1()
        {
            SetupData();
        }

        private void SetupData()
        {
            Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        [Fact]
        public void GivenListOfItems_WhenSellByDateHasPassed_ThenQualityDegradesTwiceAsFast()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<Item>{
                new Item {Name = "Test1", SellIn = 15, Quality = 50},
                new Item {Name = "Test2", SellIn = 20, Quality = 50},
                new Item {Name = "Test3", SellIn = 25, Quality = 50},
                new Item {Name = "Test4", SellIn = 0, Quality = 50},
                new Item {Name = "Test10", SellIn = 100, Quality = 50},
                new Item {Name = "Test20", SellIn = 50, Quality = 32},
                new Item {Name = "Test30", SellIn = 50, Quality = 33},
                new Item {Name = "Test40", SellIn = 80, Quality = 50},
                new Item {Name = "Test50", SellIn = 50, Quality = 50},
            };

            var itemsExpextedValues = items.Select(c => new 
            { 
                // reference data
                OriginalItem = c,
                
                //copy data
                OriginalSellIn = c.SellIn, 
                OriginalQuality = c.Quality,

                // calculate expected values
                ExpectedSellIn = c.SellIn - totalDays,
                ExpectedQuality1 = c.Quality - c.SellIn - ((totalDays - c.SellIn) * 2) <= 0 ? 0 : c.Quality - c.SellIn - ((totalDays - c.SellIn) * 2),
                ExpectedQuality2 = Math.Abs(totalDays - c.SellIn) - Math.Abs(c.Quality - c.SellIn)
            }).ToList();
            var app = new GildedRose.GildedRose(items);

            // Act
            for (var i = 0; i < totalDays; i++)
                app.UpdateQuality();

            // Assert
            //NOTE: use this query to check next Assert values in Watch window or QuickWatch window:
            itemsExpextedValues.Where(c => c.OriginalSellIn < c.OriginalQuality).Select(c => new { c.OriginalItem.SellIn, c.ExpectedSellIn, c.OriginalItem.Quality, c.ExpectedQuality1, c.ExpectedQuality2 });

            Assert.True(itemsExpextedValues.Count(c => c.OriginalSellIn < c.OriginalQuality) ==
                itemsExpextedValues.Where(c => c.OriginalSellIn < c.OriginalQuality)
                .Count(c => c.OriginalItem.SellIn == c.ExpectedSellIn && c.OriginalItem.Quality == c.ExpectedQuality1));

            //NOTE: use this query to check next Assert values in Watch window or QuickWatch window:
            itemsExpextedValues.Where(c => c.OriginalSellIn >= c.OriginalQuality).Select(c => new { c.OriginalItem.SellIn, c.ExpectedSellIn, c.OriginalItem.Quality, c.ExpectedQuality1, c.ExpectedQuality2 });

            Assert.True(itemsExpextedValues.Count(c => c.OriginalSellIn >= c.OriginalQuality) ==
                itemsExpextedValues.Where(c => c.OriginalSellIn >= c.OriginalQuality)
                .Count(c => c.OriginalItem.SellIn == c.ExpectedSellIn && c.OriginalItem.Quality == c.ExpectedQuality2));

        }
    }
}
