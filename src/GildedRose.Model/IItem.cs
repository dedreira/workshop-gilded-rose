using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public interface IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public abstract void UpdateQuality();
    }
}
