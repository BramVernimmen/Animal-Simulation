using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;

public class IsAnimalHungrySensor : LocalWorldSensorBase
{
    public override void Created()
    {
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var stats = references.GetCachedComponent<BaseAnimalStats>();

        if (stats == null)
        {
            Debug.Log("NO BASE STATS FOUND");
            return false;
        }

        return stats._isHungry;
    }

    public override void Update()
    {
    }
}
