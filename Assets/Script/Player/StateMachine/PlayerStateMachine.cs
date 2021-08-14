using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState curState { get; private set; }
    
    public void Init(PlayerState startState)
    {
        curState = startState;
        curState.Enter();
    }

    //switch from cur state to target state
    public void switchState(PlayerState targetState)
    {
        curState.Exit();
        curState = targetState;
        curState.Enter();
    }

}
