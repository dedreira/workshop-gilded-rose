using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public class ItemSulfuras : ItemBase
    {
        public ItemSulfuras()
        {
            //REQ: El artículo "Sulfuras" (Sulfuras), siendo un artículo legendario, no modifica su fecha de venta ni se degrada en calidad
            NormalDecreaseBy = 0;
            OverdueDecreaseBy = 0;
        }
    }
}
