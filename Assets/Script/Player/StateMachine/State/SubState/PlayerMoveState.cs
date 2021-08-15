using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        //change to idle state
        if (InputHandler.Instance.moveInput.magnitude == 0)
        {
            stateMachine.switchState(player.idleState);
        }
        if (InputHandler.Instance.moveInput.x!=0 && InputHandler.Instance.moveInput.x * player.faceDirection < 0)
        {
            player.Flip();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.rb.velocity = InputHandler.Instance.moveInput * player.moveSpeed * player.speedMulti;

    }

}
