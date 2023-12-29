using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartialSequencerNode : CompositeNode
{
    int current;
    protected override void OnStart()
    {
        current = 0;
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
        var child = children[current];
        switch (child.Update())
        {
            case State.Running:
                return State.Running;
            case State.Failure:
                return State.Failure;
            case State.Success:
                current++;
                break;
        }

        return current == children.Count ? State.Success : State.Running;
    }
}
