using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerNode : CompositeNode
{
    protected override void OnStart()
    {
        foreach (Node node in children)
        {
            node.finished = false;
            Recurse(node, (n) =>
            {
                n.finished = false;
            });
        }
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        foreach (Node child in children) 
        { 
            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                case State.Success:
                    break;
            }
        }

        return State.Success;
    }
}