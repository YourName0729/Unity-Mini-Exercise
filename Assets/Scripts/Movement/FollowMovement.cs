using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private Transform _trans;

    private void Awake()
    {
        _trans = transform;
        offset = _trans.position - target.position;
    }

    private void LateUpdate()
    {
        _trans.position = target.position + offset;
    }
}
