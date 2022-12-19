using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListExample : MonoBehaviour
{
    private ArrayList arrList = null;

    private void Start()
    {
            // Boxing
            // Unboxing : ����ȯ�ϴ� ������ ��ġ�°�.

        arrList = new ArrayList()
        {
            // �� ������Ʈ �迭    
            1,
            3.14,       // �� double 
            "Chang",
            'B',
            157.4f
        };

        // var : ��� �ڷ������� ������� ������ִ� ��. �� �������� �� ����.
        // typeof
        foreach (var value in arrList)
            Debug.Log(value.GetType() + ": " + value);
                

        // ������ ������ �̷��� ����ȯ�� �ؼ� ����ϴµ� ����̵�
        double d = (double)arrList[1];

        arrList.Add("asdf");
        arrList.Add(123);

        if (arrList.Contains(123))
            Debug.Log("Contain to 123");

        arrList.Sort();

        foreach (var value in arrList)
            Debug.Log(value);
    }
}
