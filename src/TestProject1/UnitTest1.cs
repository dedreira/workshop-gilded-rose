using GildedRose.Model;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace TestProject1
{
    public class UnitTest1
    {
        private IList<IItem> Items;

        [Fact]
        //REQ: Una vez que ha pasado la fecha recomendada de venta, la calidad se degrada al doble de velocidad
        //REQ: La calidad de un artículo nunca es negativa
        public void GivenListOfNormalItems_WhenSellByDateHasPassed_ThenQualityDegradesTwiceAsFast()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemNormal {Name = "Test1", SellIn = 15, Quality = 50},
                new ItemNormal {Name = "Test2", SellIn = 20, Quality = 50},
                new ItemNormal {Name = "Test3", SellIn = 25, Quality = 50},
                new ItemNormal {Name = "Test4", SellIn = 0, Quality = 50},
                new ItemNormal {Name = "Test10", SellIn = 100, Quality = 50},
                new ItemNormal {Name = "Test20", SellIn = 50, Quality = 32},
                new ItemNormal {Name = "Test30", SellIn = 50, Quality = 33},
                new ItemNormal {Name = "Test40", SellIn = 80, Quality = 50},
                new ItemNormal {Name = "Test50", SellIn = 50, Quality = 50},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact] 
        //REQ: Al final de cada día, nuestro sistema decrementa ambos valores para cada artículo
        public void GivenListOfItems_WhenSellByDateIsHigherThan0_ThenQualityDegradesOrIncreases()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemNormal {Name = "Test1", SellIn = totalDays, Quality = 50},
                new ItemNormal {Name = "Test2", SellIn = totalDays, Quality = 40},
                new ItemNormal {Name = "Test3", SellIn = totalDays, Quality = 30},
                new ItemNormal {Name = "Test4", SellIn = totalDays, Quality = 20},
                new ItemNormal {Name = "Test5", SellIn = totalDays, Quality = 10},
                new ItemNormal {Name = "Test6", SellIn = totalDays, Quality = 0},

                new ItemAgedBrie {Name = "Test1_ItemAgedBrie", SellIn = totalDays, Quality = 50},
                new ItemAgedBrie {Name = "Test2_ItemAgedBrie", SellIn = totalDays, Quality = 40},
                new ItemAgedBrie {Name = "Test3_ItemAgedBrie", SellIn = totalDays, Quality = 30},
                new ItemAgedBrie {Name = "Test4_ItemAgedBrie", SellIn = totalDays, Quality = 20},
                new ItemAgedBrie {Name = "Test5_ItemAgedBrie", SellIn = totalDays, Quality = 10},
                new ItemAgedBrie {Name = "Test6_ItemAgedBrie", SellIn = totalDays, Quality = 0},

                new ItemBackStagePass {Name = "Test1_ItemBackStagePass", SellIn = totalDays, Quality = 50},
                new ItemBackStagePass {Name = "Test2_ItemBackStagePass", SellIn = totalDays, Quality = 40},
                new ItemBackStagePass {Name = "Test3_ItemBackStagePass", SellIn = totalDays, Quality = 30},
                new ItemBackStagePass {Name = "Test4_ItemBackStagePass", SellIn = totalDays, Quality = 20},
                new ItemBackStagePass {Name = "Test5_ItemBackStagePass", SellIn = totalDays, Quality = 10},
                new ItemBackStagePass {Name = "Test6_ItemBackStagePass", SellIn = totalDays, Quality = 0},

                new ItemConjured {Name = "Test1_ItemConjured", SellIn = totalDays, Quality = 50},
                new ItemConjured {Name = "Test2_ItemConjured", SellIn = totalDays, Quality = 40},
                new ItemConjured {Name = "Test3_ItemConjured", SellIn = totalDays, Quality = 30},
                new ItemConjured {Name = "Test4_ItemConjured", SellIn = totalDays, Quality = 20},
                new ItemConjured {Name = "Test5_ItemConjured", SellIn = totalDays, Quality = 10},
                new ItemConjured {Name = "Test6_ItemConjured", SellIn = totalDays, Quality = 0},

                new ItemSulfuras {Name = "Test1_ItemSulfuras", SellIn = totalDays, Quality = 50},
                new ItemSulfuras {Name = "Test2_ItemSulfuras", SellIn = totalDays, Quality = 40},
                new ItemSulfuras {Name = "Test3_ItemSulfuras", SellIn = totalDays, Quality = 30},
                new ItemSulfuras {Name = "Test4_ItemSulfuras", SellIn = totalDays, Quality = 20},
                new ItemSulfuras {Name = "Test5_ItemSulfuras", SellIn = totalDays, Quality = 10},
                new ItemSulfuras {Name = "Test6_ItemSulfuras", SellIn = totalDays, Quality = 0},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact]
        //REQ: El "Queso Brie envejecido" (Aged brie). luego de la fecha de venta su calidad aumenta 2 unidades por día
        public void GivenListOfItemAgedBrie_WhenSellByDateIsMinorThan0_ThenQualityIncreasesTwiceAsFast()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemAgedBrie {Name = "Test1", SellIn = 0, Quality = 50},
                new ItemAgedBrie {Name = "Test2", SellIn = 0, Quality = 40},
                new ItemAgedBrie {Name = "Test3", SellIn = 0, Quality = 30},
                new ItemAgedBrie {Name = "Test4", SellIn = 0, Quality = 20},
                new ItemAgedBrie {Name = "Test5", SellIn = 0, Quality = 10},
                new ItemAgedBrie {Name = "Test6", SellIn = 0, Quality = 0},
                new ItemAgedBrie {Name = "Test7", SellIn = -5, Quality = 10},
                new ItemAgedBrie {Name = "Test8", SellIn = -10, Quality = 20},
                new ItemAgedBrie {Name = "Test10", SellIn = -20, Quality = 40},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact]
        //REQ: El "Queso Brie envejecido" (Aged brie). Su calidad aumenta en 1 unidad cada día
        public void GivenListOfItemAgedBrie_WhenSellByDateIsHigherThan0_ThenQualityIncreases()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemAgedBrie {Name = "Test1", SellIn = totalDays, Quality = 50},
                new ItemAgedBrie {Name = "Test2", SellIn = totalDays, Quality = 40},
                new ItemAgedBrie {Name = "Test3", SellIn = totalDays, Quality = 30},
                new ItemAgedBrie {Name = "Test4", SellIn = totalDays, Quality = 20},
                new ItemAgedBrie {Name = "Test5", SellIn = totalDays, Quality = 10},
                new ItemAgedBrie {Name = "Test6", SellIn = totalDays, Quality = 0},
                new ItemAgedBrie {Name = "Test7", SellIn = 10, Quality = 10},
                new ItemAgedBrie {Name = "Test8", SellIn = 10, Quality = 40},
                new ItemAgedBrie {Name = "Test9", SellIn = 0, Quality = 0},
                new ItemAgedBrie {Name = "Test10", SellIn = -20, Quality = 20},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact]
        //REQ: La calidad de un artículo nunca es mayor a 50
        //REQ: La calidad de un artículo nunca es negativa
        //REQ: Sulfuras siendo un artículo legendario posee una calidad inmutable de 80
        public void GivenListOfItems_WhenInvalidQualityIsAssigned_ThenQualityGetDefaultValue()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemNormal {Name = "Test1", SellIn = totalDays, Quality = -10},
                new ItemNormal {Name = "Test2", SellIn = totalDays, Quality = 60},
                new ItemAgedBrie {Name = "Test3", SellIn = totalDays, Quality = -10},
                new ItemAgedBrie {Name = "Test4", SellIn = totalDays, Quality = 60},
                new ItemBackStagePass {Name = "Test5", SellIn = totalDays, Quality = -10},
                new ItemBackStagePass {Name = "Test6", SellIn = totalDays, Quality = 60},
                new ItemSulfuras {Name = "Test7", SellIn = totalDays, Quality = -10},
                new ItemSulfuras {Name = "Test8", SellIn = totalDays, Quality = 90},
                new ItemConjured {Name = "Test7", SellIn = totalDays, Quality = -10},
                new ItemConjured {Name = "Test8", SellIn = totalDays, Quality = 90},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact]
        //REQ: si faltan 10 días o menos para el concierto, la calidad se incrementa en 2 unidades
        public void GivenListOfItemBackStagePasses_WhenSellInMinorThan10_ThenQualityIncreasesTwiceAsFast()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemBackStagePass {Name = "Test1", SellIn = 10, Quality = 0},
                new ItemBackStagePass {Name = "Test2", SellIn = 9, Quality = 5},
                new ItemBackStagePass {Name = "Test3", SellIn = 8, Quality = 10},
                new ItemBackStagePass {Name = "Test4", SellIn = 7, Quality = 15},
                new ItemBackStagePass {Name = "Test5", SellIn = 6, Quality = 20},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        [Fact]
        //REQ: si faltan 10 días o menos para el concierto, la calidad se incrementa en 2 unidades
        public void GivenListOfItemConjured_When_ThenQualityDegradesTwiceAsFast()
        {
            // Arrange
            const int totalDays = 31;

            var items = new List<IItem>{
                new ItemConjured {Name = "Test1", SellIn = totalDays, Quality = 50},
                new ItemConjured {Name = "Test2", SellIn = 20, Quality = 5},
                new ItemConjured {Name = "Test3", SellIn = 10, Quality = 10},
                new ItemConjured {Name = "Test4", SellIn = 0, Quality = 15},
                new ItemConjured {Name = "Test5", SellIn = -10, Quality = 20},
            };

            List<ExpectedItem> itemsExpextedValues = GetExpectedValues(totalDays, items);
            var app = new GildedRose.GildedRose(items);

            // Act
            app.Start(totalDays);

            // Assert
            AssertData(itemsExpextedValues);
        }

        private static void AssertData(List<ExpectedItem> itemsExpextedValues)
        {
            //NOTE: use this query to check next Assert values in Watch window or QuickWatch window:
            itemsExpextedValues.Select(c => new { c.OriginalItem.Name, c.OriginalItem.SellIn, c.ExpectedSellIn, c.OriginalItem.Quality, c.ExpectedQuality });

            Assert.Equal(
                itemsExpextedValues.Count(c => c.OriginalItem.SellIn == c.ExpectedSellIn && c.OriginalItem.Quality == c.ExpectedQuality),
                itemsExpextedValues.Count);
        }

        private List<ExpectedItem> GetExpectedValues(int totalDays, List<IItem> items)
        {
            var itemsExpextedValues = items.Select(c => new ExpectedItem
            {
                // reference data
                OriginalItem = c,

                //copy data
                OriginalSellIn = c.SellIn,
                OriginalQuality = c.Quality,

                // calculate expected values
                ExpectedSellIn = CalculateExpectedSellIn(c, totalDays),
                ExpectedQuality = CalculateExpectedQuality(c, totalDays),
            }).ToList();
            return itemsExpextedValues;
        }

        private int CalculateExpectedSellIn(IItem c, int totalDays)
        {
            if (c.GetType() == typeof(ItemSulfuras))
                return c.SellIn;
            else
                return c.SellIn - totalDays;
        }

        private int CalculateExpectedQuality(IItem c, int totalDays)
        {
            int result = 0;
            int validQuality = c.Quality;

            if (!c.IsValidQuality(c.Quality))
                validQuality = c.Quality < 0 ? c.GetMinimumQualityAllowed() : c.GetMaximumQualityAllowed();

            if (c.GetType() == typeof(ItemAgedBrie))
            {
                //REQ: luego de la fecha de venta su calidad aumenta 2 unidades por día
                int increaseValue;
                if (c.SellIn - totalDays >= 0)
                    increaseValue = totalDays;
                else
                    increaseValue = c.SellIn + ((totalDays - c.SellIn) * 2);

                if (validQuality + increaseValue > c.GetMaximumQualityAllowed())
                    result = validQuality + (c.GetMaximumQualityAllowed() - validQuality);
                else
                    result = validQuality + increaseValue;

            }
            else if (c.GetType() == typeof(ItemBackStagePass))
            {
                const int DaysLeft5 = 5;
                const int DaysLeft10 = 10;

                if (c.SellIn <= DaysLeft5)
                    result = (totalDays >= DaysLeft5 ? DaysLeft5 : totalDays) * 3;

                if (c.SellIn <= DaysLeft10 && totalDays <= c.SellIn)
                    result = (DaysLeft5 * 3) + ((totalDays >= DaysLeft10 ? DaysLeft10 - DaysLeft5 : totalDays - DaysLeft5) * 2);

                if (c.SellIn > DaysLeft10)
                    result = (DaysLeft5 * 3) + ((DaysLeft10 - DaysLeft5) * 2) + totalDays - DaysLeft10;

                if (!c.IsValidQuality(result + validQuality))
                    result = c.GetMaximumQualityAllowed();

            }
            else if (c.GetType() == typeof(ItemSulfuras))
            {
                //REQ: siendo un artículo legendario, no modifica su fecha de venta ni se degrada en calidad
                //NOTHING TO TODO
                result = c.GetMaximumQualityAllowed();
            }
            else if (c.GetType() == typeof(ItemNormal))
            {
                if (c.SellIn < validQuality)
                    result = validQuality - c.SellIn - ((totalDays - c.SellIn) * 2);
                else
                    result = Math.Abs(totalDays - c.SellIn) - Math.Abs(validQuality - c.SellIn);

            }
            else if (c.GetType() == typeof(ItemConjured))
            {
                //REQ: Los artículos conjurados degradan su calidad al doble de velocidad que los normales
                result = validQuality + (totalDays * 2);
            }
            else
                throw new NotImplementedException();

            return c.IsValidQuality(result) ? result : 0;
        }
    }
}
