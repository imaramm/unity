using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCoke : Beverage
{
    private void Start()
    {
        beverageName = "콜라";
        info = " 몸에 안좋은 콜라";
        price = 2000;
    }

    public override void Drink()
    {
        Debug.Log("콜라콜라콜라콜라콜라콜라콜라");
    }

}
