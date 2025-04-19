using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : State
{
    public StatePatrol(AIController ai) : base(ai) { }
    public override void Enter()
    {
        Debug.Log("Entering Patrol State");
    }

    public override void Update()
    {
      if (ai.CanSeePlayer())
        {
            ai.ChangeState(new StateChase(ai));
        }
        //else if (ai.CanHearPlayer(ai.playerVolume) && !ai.CanSeePlayer())
        //{
            //change state here
        //    ai.ChangeState(new StateSearchForPlayer(ai));
       // }
       // else
       {
           ai.Patrol();
       }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }
}
