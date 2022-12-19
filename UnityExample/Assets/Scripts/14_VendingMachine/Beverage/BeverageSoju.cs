using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageSoju : Beverage
{
    private void Start()
    {
        beverageName = "소주";
        info = "술이다";
        price = 2000;
    }
    public override void Drink()
    {
        Debug.Log("캬 취한다");
    }
}
