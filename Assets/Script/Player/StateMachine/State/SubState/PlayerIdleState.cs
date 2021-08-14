using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //change to move state
        if(InputHandler.Instance.moveInput.magnitude != 0)
        {
            stateMachine.switchState(player.moveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.rb.velocity = Vector2.zero;
    }
}
