using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCider : Beverage
{
    private void Start()
    {
        beverageName = " ���̴� ";
        info = " ������ ����";
        price = 1500;
    }
    public override void Drink()
    {
        Debug.Log("������������������");
    }
}
