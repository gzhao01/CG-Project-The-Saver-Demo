using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : PlayerState
{
    public PlayerBaseState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //change to fire hook state
        if (InputHandler.Instance.fireHook)
        {
            stateMachine.switchState(player.fireHookState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        ApplyHookDirection();
    }

    private void ApplyHookDirection()
    {
        player.hookDirectionTransform.localRotation = Quaternion.Euler(0, 0, InputHandler.Instance.mouseAngle);
    }
}
