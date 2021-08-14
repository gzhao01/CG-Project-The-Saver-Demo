using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //state machine
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerFireHookState fireHookState { get; private set; }
    public PlayerHookPeopleState hookPeopleState { get; private set; }
    public PlayerHookPointState hookPointState { get; private set; }
    public PlayerHookNullState hookNullState { get; private set; }

    [Header("Move")]
    public float moveSpeed;
    public int faceDirection { get; private set; }

    [Header("Hook")]
    public Transform hookEndTransform;
    public Transform hookDirectionTransform;
    public float hookFireSpeed;
    public float hookBackSpeed;
    public float hookFireTime;

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public HookEnd hookEnd;

    private void Awake()
    {
        //init state
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        fireHookState = new PlayerFireHookState(this, stateMachine, "FireHook");
        hookPeopleState = new PlayerHookPeopleState(this, stateMachine, "HookPeople");
        hookPointState = new PlayerHookPointState(this, stateMachine, "HookPoint");
        hookNullState = new PlayerHookNullState(this, stateMachine, "HookNull");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        hookEnd = hookEndTransform.GetComponent<HookEnd>();

        faceDirection = 1; //face right default
        //init state machine
        stateMachine.Init(idleState);
    }

    private void Update()
    {
        stateMachine.curState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.curState.PhysicUpdate();
        hookDirectionTransform.transform.position = transform.position;
    }

    public void Flip()
    {
        faceDirection *= -1;
        transform.Rotate(0, -180, 0);
    }
}
