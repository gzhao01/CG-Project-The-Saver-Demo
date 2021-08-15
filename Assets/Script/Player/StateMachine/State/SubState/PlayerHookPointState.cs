using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookPointState : PlayerAfterHookState
{
    public PlayerHookPointState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.hookEnd.rb.velocity = Vector2.zero;
        player.col.isTrigger = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.col.isTrigger = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.hookEnd.touchPlayer)
        {
            player.hookEndTransform.gameObject.SetActive(false);
            player.hookEnd.touchPlayer = false;
            stateMachine.switchState(player.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.rb.velocity = player.hookEnd.hookEnd2PlayerDir * player.hookBackSpeed * player.hookBackSpeedMulti;
    }
}
