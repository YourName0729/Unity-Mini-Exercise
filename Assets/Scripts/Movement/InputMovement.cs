using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : Movement
{
    private float _inputDx = 0.0f;
    private float _inputDz = 0.0f;

    private MoveState _moveState = MoveState.Standing;

    


    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _inputDx = Input.GetAxis("Horizontal");
        _inputDz = Input.GetAxis("Vertical");
        if (rig.velocity.y != 0.0f)
            SetMoveState(MoveState.Jumping);
        else
            SetMoveState(_inputDx != 0 || _inputDz != 0 ? MoveState.Moving : MoveState.Standing);
    }

    private void SetMoveState(MoveState newMoveState)
    {
        if (_moveState != newMoveState)
        {
            Debug.Log("Player State: " + newMoveState);
        }
        _moveState = newMoveState;
    }

    private void FixedUpdate()
    {
        //rig.velocity += new Vector3(_inputDx, 0, _inputDz) * _speed * Time.deltaTime;
        var orgVely = new Vector3(0, rig.velocity.y, 0);
        rig.velocity = new Vector3(_inputDx, 0, _inputDz) * _speed * Time.deltaTime + orgVely;
        //Debug.Log("New Vel = " + rig.velocity);
        //transform.Translate(new Vector3(_inputDx, 0, _inputDz) * _speed * Time.deltaTime);
    }

    public override void Jump(Vector3 newDirection)
    {
        SetMoveState(MoveState.Jumping);
        rig.velocity = newDirection;
    }
}