using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            int qualityValue;

            foreach (var item in Items)
            {
                //Al final de cada día, nuestro sistema decrementa ambos valores para cada artículo
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                    item.SellIn--;

                // El "Queso Brie envejecido" Su calidad aumenta en 1 unidad cada día. luego de la fecha de venta su calidad aumenta 2 unidades por día
                if (item.Name == "Aged Brie")
                    qualityValue = item.SellIn < 0 ? 2 : 1;

                // El artículo "Sulfuras", siendo un artículo legendario, no modifica su fecha de venta ni se degrada en calidad
                else if (item.Name.StartsWith("Sulfuras"))
                    qualityValue = 0;

                else if (item.Name.StartsWith("Backstage passes"))
                {
                    // si faltan 5 días o menos, la calidad se incrementa en 3 unidades
                    if (item.SellIn <= 5)
                        qualityValue = 3;
                    // si faltan 10 días o menos para el concierto, la calidad se incrementa en 2 unidades
                    else if (item.SellIn <= 10)
                        qualityValue = 2;
                    // luego de la fecha de venta la calidad cae a 0
                    else if (item.SellIn < 0)
                        qualityValue = 0;
                    // como el queso brie, incrementa su calidad a medida que la fecha de venta se aproxima
                    else //(SellIn > 10)
                        qualityValue = 1;
                }
                // Una vez que ha pasado la fecha recomendada de venta, la calidad se degrada al doble de velocidad
                else
                    qualityValue = item.SellIn < 0 ? - 2: -1;

                // La calidad de un artículo nunca es negativa
                // La calidad de un artículo nunca es mayor a 50
                if (item.Quality + qualityValue >= 0 && item.Quality + qualityValue <= 50)
                    item.Quality += qualityValue;
                // cuando Quality es impar (+1), corrige el desajuste de cuando SellIn es negativo y tiene que restar -2 pero Quality no puede ser negativo
                else if (item.Quality > 0 && qualityValue < 0)
                    item.Quality--;
            }
        }
    }
}
