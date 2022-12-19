using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 광고할 이미지 추가
// 이미지 변경 시간(간격)
// 순차적 - 랜덤인지
public class Adpanel : MonoBehaviour
{   
    // 외부에서 가져올수있게
    [SerializeField]
    private Texture2D[] adImgs = null;
    [SerializeField]
    private float interval = 0.5f;
    [SerializeField]
    private bool shuffle = false;


    private MeshRenderer mr = null;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }


    private void Start()
    {
        // 이미지가 없으면
        if (adImgs == null || adImgs.Length == 0)
            return;

        StartCoroutine(ChangeImageCoroutine());
    }


    private IEnumerator ChangeImageCoroutine()
    {
        int idx = 0;

        while (true)
        {
            // 셔플이 아닌 경우
            if (!shuffle)
            {
                mr.material.mainTexture = adImgs[idx];
                ++idx;
                //if (idx >= adImgs.Length) idx = 0;
                //idx = idx % adImgs.Length;
                // 위에꺼를 줄이면 이렇게 된다. ↙ 결과로는 둘 다 0이 되는거임~
                idx %= adImgs.Length;
            }
            else
            {
                mr.material.mainTexture = adImgs[Random.Range(0, adImgs.Length)];
            }


            yield return new WaitForSeconds(interval);
        }

    }
}
