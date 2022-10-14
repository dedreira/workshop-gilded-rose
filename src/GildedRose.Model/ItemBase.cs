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
        public bool SellInEnabled { get; set; } = true;

        public int GetMinimumQualityAllowed()
        {
            return MinimumQualityAllowed;
        }
        public int GetMaximumQualityAllowed()
        {
            return MaximumQualityAllowed;
        }

        public virtual void UpdateQuality()
        {
            //REQ: La calidad de un artículo nunca es mayor a 50
            //REQ: La calidad de un artículo nunca es negativa
            if (!IsValidQuality(Quality))
                Quality = Quality < 0 ? MinimumQualityAllowed : MaximumQualityAllowed; //set default value

            int newQuality;

            //REQ: Al final de cada día, nuestro sistema decrementa ambos valores (SellIn, Quality) para cada artículo
            if (SellInEnabled)
                SellIn -= 1;

            if (SellIn >= 0)
                // REQ: Su calidad aumenta en 1 unidad cada día 
                //NOTE: (see derived class constructors for NormalDecreaseBy setup)
                newQuality = Quality + NormalDecreaseBy;
            else
                //REQ: Una vez que ha pasado la fecha recomendada de venta, la calidad se degrada al doble de velocidad
                //REQ: luego de la fecha de venta su calidad aumenta 2 unidades por día
                //NOTE: (see derived class constructors for NormalDecreaseBy setup)
                newQuality = Quality + OverdueDecreaseBy;

            if (IsValidQuality(newQuality))
                Quality = newQuality;
        }

        public bool IsValidQuality(int quality)
        {
            //REQ: La calidad de un artículo nunca es negativa
            //REQ: La calidad de un artículo nunca es mayor a 50
            //REQ: las Sulfuras siendo un artículo legendario posee una calidad inmutable de 80
            return quality >= MinimumQualityAllowed && quality <= MaximumQualityAllowed;
        }


    }
}
