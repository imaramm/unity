using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageSoju : Beverage
{
    private void Start()
    {
        beverageName = "����";
        info = "���̴�";
        price = 2000;
    }
    public override void Drink()
    {
        Debug.Log("ļ ���Ѵ�");
    }
}
