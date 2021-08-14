using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireHookState : PlayerState
{
    public PlayerFireHookState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        InputHandler.Instance.SetFireHookInputFalse();
        player.rb.velocity = Vector2.zero;
        player.hookEndTransform.rotation = player.hookDirectionTransform.rotation;
        player.hookEndTransform.position = player.hookDirectionTransform.position;
        player.hookEndTransform.gameObject.SetActive(true);
        player.hookEnd.isFiringHook = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.hookEnd.isFiringHook = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //change to hook people state
        if (player.hookEnd.touchPeople)
        {
            stateMachine.switchState(player.hookPeopleState);
        }
        //change to hook point state
        else if (player.hookEnd.touchPoint)
        {
            stateMachine.switchState(player.hookPointState);
        }
        //change to hook null state
        else if(Time.time > startTime + player.hookFireTime)
        {
            stateMachine.switchState(player.hookNullState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.hookEnd.rb.velocity = player.hookEndTransform.right * player.hookFireSpeed;
    }
}
