using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    private void Start()
    {
        Stack stack = new Stack();
        stack.Push("a");
        stack.Push(1);
        stack.Push(3.14f);
        //foreach (object obj in stack)
        //    Debug.Log(obj);
        Debug.Log("Stack Count: " + stack.Count);

        while(stack.Count > 0)
            Debug.Log("Stack Pop: " + stack.Pop());

        Debug.Log("Stack Count: " + stack.Count);
    }
}
