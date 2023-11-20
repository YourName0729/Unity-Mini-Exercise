using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    public event Action<Collider> OnEnterRange, OnInRange, OnExitRange;
    public float a = 1f;
    private void OnTriggerEnter(Collider other)
    {
        OnEnterRange?.Invoke(other);
    }
}
