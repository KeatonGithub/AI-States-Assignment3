using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSearchForPlayer : State
{
    public StateSearchForPlayer(AIController ai) : base(ai) { }


    public override void Enter()
    {
        Debug.Log("searching for player");
    }

    public override void Update()
    {
        //throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        // throw new System.NotImplementedException();
        Debug.Log("Stop");
    }
}
