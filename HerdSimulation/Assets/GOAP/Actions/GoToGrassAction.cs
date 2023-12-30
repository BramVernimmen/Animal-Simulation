using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGrassAction : ActionBase<GoToGrassAction.Data>
{
    public override void Created()
    {
    }

    public override void Start(IMonoAgent agent, Data data)
    {
    }

    public override void End(IMonoAgent agent, Data data)
    {
    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {


        return ActionRunState.Stop;
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
    }
}
