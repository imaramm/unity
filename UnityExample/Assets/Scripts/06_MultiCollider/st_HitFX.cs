using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st_HitFX : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    private void Update()
    {
        // Vector3.one
        transform.localScale = transform.localScale + (Vector3.one * 5f * Time.deltaTime);
    }
}
