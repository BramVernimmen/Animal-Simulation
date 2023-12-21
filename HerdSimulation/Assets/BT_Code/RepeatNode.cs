using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode
{
    // Amount of times this node will get executed, put -1 for infinite loop.
    public int amountOfLoops;
    private int currentAmountOfLoops = 0;

    protected override void OnStart()
    {
        currentAmountOfLoops = 0;
    }

    protected override void OnStop()
    {
        currentAmountOfLoops = 0;
    }

    protected override State OnUpdate()
    {
        currentAmountOfLoops++;
        child.Update();

        if (amountOfLoops == -1 || currentAmountOfLoops < amountOfLoops) 
        { 
            return State.Running;
        }


        return State.Success;
    }
}
