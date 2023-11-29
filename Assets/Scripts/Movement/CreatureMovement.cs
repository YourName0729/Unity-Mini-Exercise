using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : Movement
{
    [SerializeField] private float _moveTime = 2f;
    [SerializeField] private float _idleTime = 1f;

    [SerializeField] private float _turnSpeed = 0.2f;

    private MoveState _moveState = MoveState.Standing;
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(AutoStateSwitching());
    }

    private void FixedUpdate()
    {
        if (_moveState == MoveState.Standing) return;

        var orgVely = new Vector3(0, rig.velocity.y, 0);
        rig.velocity = _moveDirection * _speed * Time.deltaTime + orgVely;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDirection), _turnSpeed * Time.deltaTime);
    }

    public override void Jump(Vector3 dir)
    {
        rig.velocity = dir;
    }

    private IEnumerator AutoStateSwitching()
    {
        while (true)
        {
            yield return new WaitForSeconds(_idleTime);
            float angle = Random.Range(0f, 2 * Mathf.PI);
            _moveDirection = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
            _moveState = MoveState.Moving;
            yield return new WaitForSeconds(_moveTime);
            _moveState = MoveState.Standing;
        }
    }
}
