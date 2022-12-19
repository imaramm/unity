using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListExample : MonoBehaviour
{
    private ArrayList arrList = null;

    private void Start()
    {
            // Boxing
            // Unboxing : 형변환하는 과정을 거치는거.

        arrList = new ArrayList()
        {
            // ↓ 오브젝트 배열    
            1,
            3.14,       // ← double 
            "Chang",
            'B',
            157.4f
        };

        // var : 어떠한 자료형인지 상관없이 만들수있는 애. 다 때려박을 수 있음.
        // typeof
        foreach (var value in arrList)
            Debug.Log(value.GetType() + ": " + value);
                

        // 더블을 쓸려면 이렇게 형변환을 해서 써야하는데 비용이들어서
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
