using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    public BehaviourTree tree;
    public Blackboard blackboard;
    void Start()
    {
        // we clone the entire tree
        // otherwise all the trees would be the same
        tree = tree.Clone();
        tree.blackboard = blackboard;
        tree.Bind(); // gives the correct blackboard to each node

    }

    void Update()
    {
        tree.Update();
    }
}
