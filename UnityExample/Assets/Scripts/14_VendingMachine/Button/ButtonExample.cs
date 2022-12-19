using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 // 버튼이 눌러졌을때 어떻게 감지하고 상호작용을 하는지보자
public class ButtonExample : MonoBehaviour
{
    [SerializeField]
    private Button btnExample = null;

    // delegate : 대리자. 포인터와 같은 개념이다.
    public delegate void DelegateExample();
    private DelegateExample callback = null;

    private void Awake()
    {
        btnExample.onClick.AddListener(OnClickEvent);
    }

    private void Start()
    {
        // ↓ 옛날 방식의 callback함수
        callback = PrintHello;
        if (callback != null)
        callback();

        // ↓ 요즘 쓰는 방식
        callback = PrintWorld;
        callback?.Invoke();
    }

    public void OnClickEvent()
    {
        Debug.Log("Button Click Event!");
    }

    private void PrintHello()
    {
        Debug.Log("Hello");
    }

    private void PrintWorld()
    {
        Debug.Log("World");
    }
}
