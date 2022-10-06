using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Model
{
    public class ItemBackStagePass : ItemBase
    {
        public override void UpdateQuality()
        {
            //REQ: si faltan 5 días o menos, la calidad se incrementa en 3 unidades
            if (SellIn <= 5)
                NormalDecreaseBy = 3;
            
            //REQ: si faltan 10 días o menos para el concierto, la calidad se incrementa en 2 unidades
            else if (SellIn <= 10)
                NormalDecreaseBy = 2;
            
            //REQ: luego de la fecha de venta la calidad cae a 0
            else if (SellIn < 0)
                OverdueDecreaseBy = 0;
            
            //REQ: como el queso brie, incrementa su calidad a medida que la fecha de venta se aproxima
            else //(SellIn > 10)
                NormalDecreaseBy = 1;

            base.UpdateQuality();
        }
    }
}
