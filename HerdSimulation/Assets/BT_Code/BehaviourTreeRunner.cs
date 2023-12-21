using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    BehaviourTree tree;

    // Start is called before the first frame update
    void Start()
    {
        tree = ScriptableObject.CreateInstance<BehaviourTree>();
        var log1 = ScriptableObject.CreateInstance<DebugLogNode>();
        log1.message = "DEBUGGING 111111";

        var log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        log2.message = "DEBUGGING 22222";
        
        var wait = ScriptableObject.CreateInstance<WaitNode>();
        wait.duration = 2.0f;
        
        var log3 = ScriptableObject.CreateInstance<DebugLogNode>();
        log3.message = "DEBUGGING 33333333";

        var seq = ScriptableObject.CreateInstance<SequencerNode>();
        seq.children.Add(log1);
        seq.children.Add(wait);
        seq.children.Add(log2);
        seq.children.Add(wait);
        seq.children.Add(log3);
        seq.children.Add(wait);

        var repeat = ScriptableObject.CreateInstance<RepeatNode>();
        repeat.child = seq;
        repeat.amountOfLoops = -1;

        tree.rootNode = repeat;
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
