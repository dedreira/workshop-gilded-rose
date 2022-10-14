using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public class ItemConjured : ItemBase
    {
        public ItemConjured()
        {
            //REQ: Los artículos conjurados degradan su calidad al doble de velocidad que los normales
            NormalDecreaseBy = -2;
            OverdueDecreaseBy = -2;
        }
    }
}
