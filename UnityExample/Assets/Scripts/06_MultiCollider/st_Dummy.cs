using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st_Dummy : MonoBehaviour
{
    // rigidbody = collision....
    // �����ε� �����ε�

    private void OnCollisionEnter(Collision _collision)
    {
        Debug.Log("Collision:" + _collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Trigger:" + _other.name);
    }

}
