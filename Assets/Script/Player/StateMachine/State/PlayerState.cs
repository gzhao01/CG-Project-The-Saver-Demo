using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        player.anim.SetBool(animBoolName, true);
        //Debug.Log("enter " + animBoolName);
    }

    public virtual void LogicUpdate()
    {
        //change to dizzy state
        if(stateMachine.curState != player.deadState && stateMachine.curState != player.dizzyState)
        {

        }
        //change to dead state
        if(stateMachine.curState != player.deadState && player.collideWave)
        {
            stateMachine.switchState(player.deadState);
        }

    }

    public virtual void PhysicUpdate()
    {

    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void DoChecks()
    {

    }
}
