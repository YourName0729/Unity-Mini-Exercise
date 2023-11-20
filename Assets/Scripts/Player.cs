using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 4f;

    private void Start()
    {
        var detector = transform.GetChild(0).GetComponent<RangeDetector>();
        detector.OnEnterRange += OnSomethingEnterExpRange;
    }

    private void OnDestroy()
    {
        var detector = transform.GetChild(0).GetComponent<RangeDetector>();
        detector.OnEnterRange -= OnSomethingEnterExpRange;
    }

    void Update()
    {
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(dx, 0, dz) * Time.deltaTime * speed);      
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Touch" + other.gameObject.name);
        if (other.gameObject.tag == "Exp")
        {
            Debug.Log("Touch Exp!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touch2" + other.gameObject.name);
        if (other.gameObject.tag == "Exp")
        {
            Debug.Log("Touch Exp!");
        }
    }

    void OnSomethingEnterExpRange(Collider other)
    {
        if (other.gameObject.tag == "Exp")
        {
            Debug.Log("Exp in range");
        }
        else
        {
            Debug.Log("What? " + other.gameObject.name);
        }
    }
}
