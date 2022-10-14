using GildedRose.Model;

namespace TestProject1
{
    internal class ExpectedItem
    {
        public IItem OriginalItem { get; set; }
        public int OriginalSellIn { get; set; }
        public int OriginalQuality { get; set; }
        public int ExpectedSellIn { get; set; }
        public int ExpectedQuality { get; set; }
    }
}