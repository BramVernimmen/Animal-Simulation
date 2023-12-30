using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoveBehaviour : MonoBehaviour
{
    private AgentBehaviour agent;
    private ITarget currentTarget;
    private bool shouldMove;
    private BaseAnimalStats stats;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
        stats = this.GetComponent<BaseAnimalStats>();
    }

    private void OnEnable()
    {
        this.agent.Events.OnTargetInRange += this.OnTargetInRange;
        this.agent.Events.OnTargetChanged += this.OnTargetChanged;
        this.agent.Events.OnTargetOutOfRange += this.OnTargetOutOfRange;
    }

    private void OnDisable()
    {
        this.agent.Events.OnTargetInRange -= this.OnTargetInRange;
        this.agent.Events.OnTargetChanged -= this.OnTargetChanged;
        this.agent.Events.OnTargetOutOfRange -= this.OnTargetOutOfRange;
    }

    private void OnTargetInRange(ITarget target)
    {
        this.shouldMove = false;
    }

    private void OnTargetChanged(ITarget target, bool inRange)
    {
        this.currentTarget = target;
        this.shouldMove = !inRange;
    }

    private void OnTargetOutOfRange(ITarget target)
    {
        this.shouldMove = true;
    }

    public void Update()
    {
        if (!this.shouldMove)
            return;

        if (this.currentTarget == null)
            return;

        this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentTarget.Position.x, transform.position.y, currentTarget.Position.z), Time.deltaTime * stats._currentSpeed);
    }

    private void OnDrawGizmos()
    {
        if (this.currentTarget == null)
            return;

        Gizmos.DrawLine(this.transform.position, this.currentTarget.Position);
    }
}
