using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] GameObject explosion;

    private Animator anim;

    private static readonly int animMove = Animator.StringToHash("isMoving");
    private static readonly int animAttack = Animator.StringToHash("attack");
    private static readonly int animIsAlive = Animator.StringToHash("isAlive");
    private static readonly int animGetHit = Animator.StringToHash("get hit");

    private static readonly int animGetHitState = Animator.StringToHash("GetHit");
    private static readonly int animAttackState = Animator.StringToHash("Attack01");
    private static readonly int animDieState = Animator.StringToHash("Die");

    Vector3 moveDir;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        DestroyOnDie behav = anim.GetBehaviour<DestroyOnDie>();
        behav.OnDead += OnDead;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger(animAttack);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger(animGetHit);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool(animIsAlive, false);
        }

        Move();
    }

    void Move()
    {
        int state = anim.GetCurrentAnimatorStateInfo(0).shortNameHash;
        //Debug.Log(string.Format("{0}, {1}, {2}", state, animGetHitState, animAttackState));
        if (state == animAttackState || state == animGetHitState || state == animDieState) return;

        float dx = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float dz = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, 0, dz);
        transform.Rotate(0, dx, 0);

        anim.SetBool(animMove, dz != 0f);
        
    }

    void OnDead()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
