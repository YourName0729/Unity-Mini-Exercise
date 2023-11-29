using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    Standing,
    Moving,
    Jumping
}
public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float _speed = 1.0f;

    public abstract void Jump(Vector3 dir);

    public float speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
}
