using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float _accAmount = 20.0f;
    //[SerializeField] private int _accTicks = 20.0f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + other.gameObject.name);
        var movement = other.gameObject.GetComponent<Movement>();
        if (movement == null) return;
        movement.speed += _accAmount;
    }

    private void OnTriggerExit(Collider other)
    {
        var movement = other.gameObject.GetComponent<Movement>();
        if (movement == null) return;
        movement.speed -= _accAmount;
    }

    //private IEnumerator Accelerate(GameObject target, bool activate)
    //{

    //}
}
