using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private float movingSpeed = 10f;

    //private void Update()
    //{
    //    MovingWithAxis();
    //}

    //private void MovingWithAxis()
    //{
    //    float axisV = Input.GetAxis("Vertical");
    //    float axisH = Input.GetAxis("Horizontal");

    //    transform.Translate(Vector3.forward * axisV * movingSpeed * Time.deltaTime);
    //    transform.Translate(Vector3.right * axisH * movingSpeed * Time.deltaTime);
    //}
    //-------------------------------------------------------------------------------------------------------------------------------



    private CharacterController cc = null;
    private Camera cam = null;

    private float moveSpeed = 5000f;
    private float rotSpeed = 100f;
    private Vector3 camRot = Vector3.zero;

    private float moveFast = 10000f;


    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        MovingProcess();
        LookProcess();
    }

    private void MovingProcess()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        Vector3 camF = cam.transform.forward;
        camF.y = 0f; // y���� 0���� ����� (�ƴϸ� �ϴ÷� ���󰡹����ϱ�)
        camF.Normalize(); // �׷��� ���̰� 1�� ���Ͱ� ���������
        Vector3 dirf = camF * axisV;

        Vector3 camR = cam.transform.right;
        camR.y = 0f;
        camR.Normalize();
        Vector3 dirR = camR * axisH;

        Vector3 dir = dirf + dirR;
        dir.Normalize();

        //cc.Move �߷��� �����ϰ�
        // rigidbody�� ������ ���ù��긦, �߷°���ؼ� �־���.
        cc.SimpleMove(dir * moveSpeed * Time.deltaTime);
    }

    private void MoveFast()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
    }


    private void LookProcess()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camRot.x += -mouseY * rotSpeed * Time.deltaTime;
        camRot.y += mouseX * rotSpeed * Time.deltaTime;
        camRot.z = 0f;
        cam.transform.rotation = Quaternion.Euler(camRot);

        //Vector3 rot = new Vector3(-mouseY, mouseX, 0f);
        //transform.Rotate(rot * rotSpeed * Time.deltaTime);
    }



}// end of class Player
