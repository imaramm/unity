using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // prefab����ĭ����°�
    [SerializeField]
    private GameObject bgPrefab = null;

    // ��׶��� ī��Ʈ. 3���� �����ϲ�
    [SerializeField]
    private int bgCnt = 3;

    // ������ �ӵ� ��Ʈ��
    [SerializeField, Range(1f, 5f)]
    private float scrollSpeed = 1f;

    // ���� �� �پ ���� ����. ����Ƽâ���� ���� �Űܺ��� ��ġ������ �Է��ϸ��
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
            // �����̱�
            foreach (Transform tr in bgList)
            {
                Vector3 newPos = tr.position;
                newPos.x -= scrollSpeed * Time.deltaTime;
                tr.position = newPos;
            }

            // �����˻�
            if(bgList[firstIdx].position.x <= boundLeft)
            {
                // ��ġ �ű��
                Vector3 newPos = bgList[lastIdx].position;
                newPos.x += bgOffset;
                bgList[firstIdx].position = newPos;

                // �ε��� ���� 
                lastIdx = firstIdx;
                firstIdx = (firstIdx + 1) % bgCnt;
            }

            yield return null;
        }

        // Parallex Scrolling ������ũ�̷Ѹ� ���ٰ�. �ָ��ִ°� õõ�� �����̰� ������ �ִ°� ������ �����̴�

    }


}// end of class BGScroll
