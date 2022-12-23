using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st_TriggerController : MonoBehaviour
{
    [SerializeField]
    private bool useAuto = false;

    private float moveSpeed = 10f;

    private readonly float XMIN = -5f;
    private const float XMAX = 5f;

    private float t = 0f;

    private void InputProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x < XMIN)
            {
                Vector3 newPos = transform.position;
                newPos.x = XMIN;
                transform.position = newPos;
            }
        }

    }// end of Inputprocess

    // useAuto를 쓰기위한
    private void AutoMoveProcess()
    {
        t += Time.deltaTime;
        if (t > 1f) t = 0f;

        float lerpX = Mathf.Lerp(XMIN, XMAX, t);
        Vector3 newPos = transform.position;
        newPos.x = lerpX;
        transform.position = newPos;
    }

    private void Update()
    {
        if (!useAuto) InputProcess();
        else AutoMoveProcess();
    }

}// end of class st_TriggerController
   