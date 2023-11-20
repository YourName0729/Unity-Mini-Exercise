using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rgd;

    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit Dont Move!");
        rgd.velocity = Vector3.zero;
    }
}
