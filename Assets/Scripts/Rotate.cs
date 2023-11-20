using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 40f;

    [SerializeField] KeyCode xpself = KeyCode.None;
    [SerializeField] KeyCode xnself = KeyCode.None;
    [SerializeField] KeyCode ypself = KeyCode.None;
    [SerializeField] KeyCode ynself = KeyCode.None;
    [SerializeField] KeyCode zpself = KeyCode.None;
    [SerializeField] KeyCode znself = KeyCode.None;

    [SerializeField] KeyCode xpworld = KeyCode.None;
    [SerializeField] KeyCode xnworld = KeyCode.None;
    [SerializeField] KeyCode ypworld = KeyCode.None;
    [SerializeField] KeyCode ynworld = KeyCode.None;
    [SerializeField] KeyCode zpworld = KeyCode.None;
    [SerializeField] KeyCode znworld = KeyCode.None;
    void Update()
    {
        Move(xpself, new Vector3(1, 0, 0));
        Move(xnself, new Vector3(-1, 0, 0));
        Move(ypself, new Vector3(0, 1, 0));
        Move(ynself, new Vector3(0, -1, 0));
        Move(zpself, new Vector3(0, 0, 1));
        Move(znself, new Vector3(0, 0, -1));

        Move(xpworld, new Vector3(1, 0, 0), Space.World);
        Move(xnworld, new Vector3(-1, 0, 0), Space.World);
        Move(ypworld, new Vector3(0, 1, 0), Space.World);
        Move(ynworld, new Vector3(0, -1, 0), Space.World);
        Move(zpworld, new Vector3(0, 0, 1), Space.World);
        Move(znworld, new Vector3(0, 0, -1), Space.World);
    }

    private void Move(KeyCode code, Vector3 direction, Space space = Space.Self)
    {
        if (code != KeyCode.None && Input.GetKey(code))
        {
            transform.Rotate(direction * _rotateSpeed * Time.deltaTime, space);
        }
    }
}
