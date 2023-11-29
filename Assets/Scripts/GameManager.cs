using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] targets;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveSystem.Save(targets);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveSystem.Load(targets);
        }
    }
}
