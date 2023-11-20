using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private float _inputDx = 0.0f;
    private float _inputDz = 0.0f;

    [SerializeField] private float _speed = 1.0f;

    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _inputDx = Input.GetAxis("Horizontal");
        _inputDz = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rig.velocity += new Vector3(_inputDx, 0, _inputDz) * _speed * Time.deltaTime;
        //transform.Translate(new Vector3(_inputDx, 0, _inputDz) * _speed * Time.deltaTime);
    }
}
