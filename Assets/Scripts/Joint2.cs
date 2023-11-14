using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint2 : MonoBehaviour
{
    private float _rotateSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(_rotateSpeed, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(new Vector3(-_rotateSpeed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,_rotateSpeed, 0) * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(new Vector3(0, -_rotateSpeed, 0) * Time.deltaTime, Space.World);
        }
    }
}
