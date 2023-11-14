using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Period : MonoBehaviour
{

    private float angle = 0f;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _amplitude = 1f;
    private float _baseY;

    private void Start()
    {
        _baseY = transform.position.y;
    }

    void Update()
    {
        angle += _moveSpeed * Time.deltaTime;
        var pos = transform.position;
        transform.position = new Vector3(pos.x, _baseY + _amplitude * Mathf.Sin(angle), pos.z);
    }
}
