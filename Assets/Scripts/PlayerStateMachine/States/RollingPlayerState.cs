using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPlayerState : PlayerState
{
    private static float rollDistance = 3f;
    private static float rollSpeed = 2f;
    private Vector3 destination;
    private Vector3 hitpoint;

    public RollingPlayerState(PlayerController playerController, Vector3 hitpoint) : base(playerController)
    {
        this.playerController = playerController;
        this.hitpoint = hitpoint;
    }

    public override void Enter()
    {
        playerController.animator.SetTrigger("Rolling");

        Vector3 start = playerController.transform.position;
        Vector3 rollOffset = (hitpoint - start).normalized * rollDistance;
        destination = start + rollOffset;
        playerController.navMeshAgent.destination = destination;
        playerController.navMeshAgent.speed *= rollSpeed;
    }

    public override void Leave()
    {
        playerController.navMeshAgent.speed /= rollSpeed;
    }

    public override PlayerState Tick()
    {
        if (playerController.navMeshAgent.remainingDistance <= playerController.navMeshAgent.stoppingDistance)
        {
            return new IdlePlayerState(playerController);
        }

        return null;
    }
}
