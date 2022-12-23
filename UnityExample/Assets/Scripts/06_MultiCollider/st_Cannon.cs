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

             /*방법 1.
             현재 마우스 위치를 월드로 보낸다. (Screen → World)
            이후 반직선을 따로 만들어준다.
            Vector3 screenToWorld =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);*/

            // ↓ 반직선으로 충돌 검출하는거
            // 방법 2.
            // screenpoint에 있는걸 월드좌표말고 그냥 아예 Ray로 만드는것도있다. true/false로 검출.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            /*
             ↓ 반직선 만들어주는 코드
             out = 포인터 역할. 밖에서 채워 역할을 해줌
             out과 ref모두 주소접근 키워드이다. 
            out은 함수 내부에서 값이 들어간다는 보장이 있는 경우 사용
             */
            if(Physics.Raycast(ray, out hit))
            {
                // hit안에는 현재 hit된 객체의 정보가 들어가있다.
                Debug.Log("(Cannon) Hit:" + hit.transform.name);

                // 
                Instantiate(hitFXprefab, hit.point, Quaternion.identity);
            }
        }
    }

}// end of class st_Cannon
