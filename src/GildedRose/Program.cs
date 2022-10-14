using GildedRose.Model;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<IItem> items = new List<IItem>{
                new ItemNormal {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new ItemAgedBrie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new ItemNormal {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new ItemSulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new ItemSulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new ItemBackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new ItemBackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new ItemBackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new ItemNormal {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(items);
            app.Start(31);
        }
    }
}
