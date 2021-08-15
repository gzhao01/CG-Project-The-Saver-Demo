using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookNullState : PlayerAfterHookState
{
    public PlayerHookNullState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.hookEnd.touchNull = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.hookEnd.touchNull = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.hookEnd.touchPlayer)
        {
            player.hookEndTransform.gameObject.SetActive(false);
            player.hookEnd.touchPlayer = false;
            //change to idle state
            stateMachine.switchState(player.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.rb.velocity = InputHandler.Instance.moveInput * player.moveSpeed * player.speedMulti;
        player.hookEnd.rb.velocity = -player.hookEnd.hookEnd2PlayerDir * player.hookBackSpeed * player.hookBackSpeedMulti;
    }
}
