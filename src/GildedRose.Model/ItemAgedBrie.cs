using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public class ItemAgedBrie : ItemBase
    {
        public ItemAgedBrie()
        {
            // REQ: El "Queso Brie envejecido"(Aged brie) incrementa su calidad a medida que se pone viejo
            // REQ: Su calidad aumenta en 1 unidad cada día
            NormalDecreaseBy = 1;

            // REQ: luego de la fecha de venta su calidad aumenta 2 unidades por día
            OverdueDecreaseBy = 2;
        }
    }
}
