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
    public PlayerDeadState deadState { get; private set; }
    public PlayerDizzyState dizzyState { get; private set; }

    [Header("Move")]
    public float moveSpeed;
    public int faceDirection { get; private set; }

    [Header("Hook")]
    public Transform hookEndTransform;
    public Transform hookDirectionTransform;
    public float hookFireSpeed;
    public float hookBackSpeed;
    public float hookFireTime;

    //debuff
    public int savingPeopleNum = 0;
    public float speedMulti = 1;//default 1
    public float fireHookSpeedMulti = 1;
    public float hookBackSpeedMulti = 1;

    //component
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public HookEnd hookEnd;
    public BoxCollider2D col { get; private set; }

    //collide
    public bool collideWave;

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
        deadState = new PlayerDeadState(this, stateMachine, "Dead");
        dizzyState = new PlayerDizzyState(this, stateMachine, "Dizzy");

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        hookEnd = hookEndTransform.GetComponent<HookEnd>();
        col = GetComponent<BoxCollider2D>();

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

    public void AddDebuff()
    {
        speedMulti -= 0.2f;
        hookBackSpeedMulti -= 0.1f;
        fireHookSpeedMulti -= 0.1f;
    }

    public void DebuffReset()
    {
        speedMulti =1f;
        hookBackSpeedMulti = 1f;
        fireHookSpeedMulti = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collide wave, game over
        if(collision.tag == "Wave")
        {
            collideWave = true;
        }
        if(collision.tag == "SendSavedPoint" && savingPeopleNum !=0)
        {
            DebuffReset();
            GameManager.Instance.AddSaveCount(savingPeopleNum);
            savingPeopleNum = 0;
        }

    }
}
