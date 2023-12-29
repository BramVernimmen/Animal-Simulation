using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartialSelectorNode : CompositeNode
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
        // we have either a success or a failure
    }

    protected override State OnUpdate()
    {
        var child = children[current];
        switch (child.Update())
        {
            case State.Running:
                return State.Running;
            case State.Failure:
                current++;
                break;
            case State.Success:
                return State.Success;
        }

        return current == children.Count ? State.Failure : State.Running;
    }
}
