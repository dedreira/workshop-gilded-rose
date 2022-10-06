using GildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        IList<IItem> Items;
        public GildedRose(IList<IItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                item.UpdateQuality();
        }

        public void Start(IList<IItem> Items, int NumberOfDays)
        {
            var app = new GildedRose(Items);


            for (var i = 0; i < NumberOfDays; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }

    }
}
