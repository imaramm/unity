using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �̹��� �߰�
// �̹��� ���� �ð�(����)
// ������ - ��������
public class Adpanel : MonoBehaviour
{   
    // �ܺο��� �����ü��ְ�
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
        // �̹����� ������
        if (adImgs == null || adImgs.Length == 0)
            return;

        StartCoroutine(ChangeImageCoroutine());
    }


    private IEnumerator ChangeImageCoroutine()
    {
        int idx = 0;

        while (true)
        {
            // ������ �ƴ� ���
            if (!shuffle)
            {
                mr.material.mainTexture = adImgs[idx];
                ++idx;
                //if (idx >= adImgs.Length) idx = 0;
                //idx = idx % adImgs.Length;
                // �������� ���̸� �̷��� �ȴ�. �� ����δ� �� �� 0�� �Ǵ°���~
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
