using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // prefab넣을칸만드는거
    [SerializeField]
    private GameObject bgPrefab = null;

    // 백그라운드 카운트. 3개로 움직일꺼
    [SerializeField]
    private int bgCnt = 3;

    // 움직일 속도 컨트롤
    [SerializeField, Range(1f, 5f)]
    private float scrollSpeed = 1f;

    // 옆에 딱 붙어서 나올 간격. 유니티창에서 얼추 옮겨보고 수치값보고 입력하면됨
    [SerializeField]
    private float bgOffset = 3.19f;


    private float boundLeft = -5f;
    private List<Transform> bgList = new List<Transform>();

    private int firstIdx = 0;
    private int lastIdx = 0;

    private void Start()
    {
        BuildBackground();

        firstIdx = 0;
        lastIdx = bgCnt - 1;

        StartCoroutine(ScrollCoroutine());
    }

    private void BuildBackground()
    {
        for (int i = 0; i < bgCnt; ++i)
        {
            GameObject go = Instantiate(bgPrefab, new Vector3(i * bgOffset, 0f, 0f), Quaternion.identity);

            bgList.Add(go.transform);
        }
    }

    private IEnumerator ScrollCoroutine()
    {
        while (true)
        {
            // 움직이기
            foreach (Transform tr in bgList)
            {
                Vector3 newPos = tr.position;
                newPos.x -= scrollSpeed * Time.deltaTime;
                tr.position = newPos;
            }

            // 범위검사
            if(bgList[firstIdx].position.x <= boundLeft)
            {
                // 위치 옮기기
                Vector3 newPos = bgList[lastIdx].position;
                newPos.x += bgOffset;
                bgList[firstIdx].position = newPos;

                // 인덱스 정리 
                lastIdx = firstIdx;
                firstIdx = (firstIdx + 1) % bgCnt;
            }

            yield return null;
        }

        // Parallex Scrolling 시차스크ㅜ롤링 원근감. 멀리있는건 천천히 움직이고 가까이 있는건 빠르게 움직이는

    }


}// end of class BGScroll
