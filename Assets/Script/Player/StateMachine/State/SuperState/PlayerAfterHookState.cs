using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterHookState : PlayerState
{
    public PlayerAfterHookState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.hookEnd.afterHook = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.hookEnd.afterHook = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
