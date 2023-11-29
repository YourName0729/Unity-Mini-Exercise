using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    [SerializeField] private float _velocityY = 500f;

    private void OnTriggerEnter(Collider other)
    {
        var movement = other.gameObject.GetComponent<Movement>();
        if (movement == null)
        {
            Debug.Log("Touch " + other.gameObject.name);
            return;
        }
        movement.Jump(new Vector3(0, _velocityY, 0));
    }
}
