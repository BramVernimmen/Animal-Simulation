using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    [HideInInspector] public State state = State.Running;
    [HideInInspector] public bool started = false;
    [HideInInspector] public bool finished = false;
    [HideInInspector] public string guid;
    [HideInInspector] public Vector2 position;
    [HideInInspector] public Blackboard blackboard;
    [TextArea] public string description;

    public State Update()
    {
        if (!started)
        {
            OnStart();
            started = true;
            finished = false;
        }

        state = OnUpdate();

        if (state == State.Failure || state == State.Success) 
        {
            OnStop();
            started = false;
            finished = true;
        }

        return state;
    }

    public void Recurse(Node node, System.Action<Node> visiter)
    {
        if (node)
        {
            visiter.Invoke(node);

            CompositeNode compositeNode = node as CompositeNode;
            if (compositeNode != null) 
            { 
                compositeNode.children.ForEach((n) => Recurse(n, visiter));
            }

            DecoratorNode decoratorNode = node as DecoratorNode;
            if (decoratorNode != null && decoratorNode.child != null)
            {
                visiter.Invoke(decoratorNode.child);
            }
        }
    }

    public virtual Node Clone()
    {
        return Instantiate(this);
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
