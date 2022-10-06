using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public abstract class ItemBase : Item, IItem
    {
        protected int NormalDecreaseBy { get; set; } = -1;
        protected int OverdueDecreaseBy { get; set; } = -2;
        protected int MinimumQualityAllowed { get; set; } = 0;
        protected int MaximumQualityAllowed { get; set; } = 50;
        public virtual void UpdateQuality()
        {
            //REQ: Al final de cada día, nuestro sistema decrementa ambos valores (SellIn, Quality) para cada artículo
            int newSellIn = SellIn - 1;
            int newQuality;

            if (newSellIn >= 0)
            {
                SellIn = newSellIn;
                // REQ: Su calidad aumenta en 1 unidad cada día 
                //NOTE: (see derived class constructors for NormalDecreaseBy setup)
                newQuality = Quality + NormalDecreaseBy;
            }
            else
                //REQ: Una vez que ha pasado la fecha recomendada de venta, la calidad se degrada al doble de velocidad
                //REQ: luego de la fecha de venta su calidad aumenta 2 unidades por día
                //NOTE: (see derived class constructors for NormalDecreaseBy setup)
                newQuality = Quality + OverdueDecreaseBy;

            //REQ: La calidad de un artículo nunca es negativa
            //REQ: La calidad de un artículo nunca es mayor a 50
            if (IsValidQuality(newQuality))
                Quality = newQuality;
        }

        protected bool IsValidQuality(int quality)
        {
            return quality >= MinimumQualityAllowed && quality <= MaximumQualityAllowed;
        }


    }
}
