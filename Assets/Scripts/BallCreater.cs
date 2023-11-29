using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreater : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private int _initNumber = 20;
    [SerializeField] private int _updateNumber = 2;

    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject upperWall;
    [SerializeField] private GameObject lowerWall;

    private float rBall;
    private float xMin, xMax, zMin, zMax;

    private void Start()
    {
        xMin = leftWall.transform.position.x;
        xMax = rightWall.transform.position.x;
        zMin = lowerWall.transform.position.z;
        zMax = upperWall.transform.position.z;

        rBall = ballPrefab.transform.position.y;

        for (int i = 0; i < _initNumber; ++i)
        {
            CreateBall();
        }   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _updateNumber; ++i)
            {
                RemoveBall();
            }
            for (int i = 0; i < _updateNumber; ++i)
            {
                CreateBall();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateBall();
        }
    }

    private void RemoveBall()
    {
        int n = transform.childCount;
        if (n == 0) return;
        int k = Random.Range(0, n - 1);
        Transform ball = transform.GetChild(k);
        Destroy(ball.gameObject);
    }

    private void CreateBall()
    {
        Vector3 pos;
        pos.y = rBall;
        int hitCount;
        int cnt = 0;

        do
        {
            pos.x = Random.Range(xMin + rBall, xMax - rBall);
            pos.z = Random.Range(zMin + rBall, zMax - rBall);
            Collider[] colliders = Physics.OverlapSphere(pos, rBall);
            hitCount = colliders.Length;
            cnt++;
        } while (hitCount > 1 && cnt < 100);

        if (cnt == 100) Debug.LogError("No Space to Create Ball!");
        else
        {
            var newBall = Instantiate(ballPrefab, pos, Quaternion.identity);
            newBall.transform.parent = transform;
        }
    }
}
