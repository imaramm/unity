using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraidPlayerNew : MonoBehaviour
{
    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsRun", Input.GetKey(KeyCode.D));
    }
}
