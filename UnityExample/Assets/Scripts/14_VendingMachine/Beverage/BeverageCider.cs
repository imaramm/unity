using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCider : Beverage
{
    private void Start()
    {
        beverageName = " ªÁ¿Ã¥Ÿ ";
        info = " ≈ı∏Ì«— ¿Ω∑·";
        price = 1500;
    }
    public override void Drink()
    {
        Debug.Log("≈Â≈Â≈Â≈Â≈Â≈Â≈Â≈ÂΩ¥Á");
    }
}
