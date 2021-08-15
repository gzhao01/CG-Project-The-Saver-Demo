using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookPeopleState : PlayerAfterHookState
{
    public PlayerHookPeopleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        // 显示debuff
        GameManager.Instance.ShowDebuff(true);
    }

    public override void Exit()
    {
        base.Exit();
        player.savingPeopleNum++;
        player.AddDebuff();
        // 隐藏debuff、增加得分与救人数
        
        GameManager.Instance.AddPoints();
        GameManager.Instance.ShowDebuff(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.hookEnd.touchPlayer)
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
