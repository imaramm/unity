using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st_Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject hitFXprefab = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

             /*��� 1.
             ���� ���콺 ��ġ�� ����� ������. (Screen �� World)
            ���� �������� ���� ������ش�.
            Vector3 screenToWorld =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);*/

            // �� ���������� �浹 �����ϴ°�
            // ��� 2.
            // screenpoint�� �ִ°� ������ǥ���� �׳� �ƿ� Ray�� ����°͵��ִ�. true/false�� ����.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            /*
             �� ������ ������ִ� �ڵ�
             out = ������ ����. �ۿ��� ä�� ������ ����
             out�� ref��� �ּ����� Ű�����̴�. 
            out�� �Լ� ���ο��� ���� ���ٴ� ������ �ִ� ��� ���
             */
            if(Physics.Raycast(ray, out hit))
            {
                // hit�ȿ��� ���� hit�� ��ü�� ������ ���ִ�.
                Debug.Log("(Cannon) Hit:" + hit.transform.name);

                // 
                Instantiate(hitFXprefab, hit.point, Quaternion.identity);
            }
        }
    }

}// end of class st_Cannon
