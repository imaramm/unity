using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private UnityEngine.Coroutine coroutineExample = null;

    private void Start()
    {
        coroutineExample=StartCoroutine(CoroutineExample());
        StartCoroutine("CountCoroutine");
    }

    private void Update()
    {
            // 문자열로 coroutine을 정지
        if (Input.GetKeyDown(KeyCode.X))
        {
            StopCoroutine(coroutineExample);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StopCoroutine("CountCoroutine");
        }
            // 모든 coroutine을 정지.
            // 외부에서 끝내버리는.
        if (Input.GetKeyDown(KeyCode.C))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator CoroutineExample()
    {
        while (true)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(1f);
            Debug.Log("2");
            yield return new WaitForSeconds(1f);
            Debug.Log("3");
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            Debug.Log("-");
            //yield return new WaitForSeconds(0.3f);

            // ↓ 만나는 순간 완전 끝나버리는(내부에서 끝내버리는)
            //yield break;

            // ↓ 권한이 갔다가 오는
            yield return null;
        }
    }
}
