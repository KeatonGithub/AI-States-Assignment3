using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State  //defining the class state
{
    protected AIController ai;
    public State(AIController ai)
    {
        this.ai = ai;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
