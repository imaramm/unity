using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCoke : Beverage
{
    private void Start()
    {
        beverageName = "�ݶ�";
        info = " ���� ������ �ݶ�";
        price = 2000;
    }

    public override void Drink()
    {
        Debug.Log("�ݶ��ݶ��ݶ��ݶ��ݶ��ݶ��ݶ�");
    }

}
