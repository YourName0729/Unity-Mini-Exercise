using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint1 : MonoBehaviour
{

    private float _rotateSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(1, 0, 0) * _rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * _rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0) * _rotateSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, -1, 0) * _rotateSpeed * Time.deltaTime, Space.World);
        }
    }
}
