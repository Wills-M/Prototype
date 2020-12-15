using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(PlayerController pc) : base(pc)
    {
        playerController = pc;
    }

    public override void Enter()
    {
        playerController.animator.SetTrigger("Idle");
    }

    public override void Leave()
    {

    }

    public override PlayerState Tick()
    {
        playerController.HandleInput();

        if (playerController.navMeshAgent.remainingDistance > playerController.navMeshAgent.stoppingDistance)
        {
            return new RunningPlayerState(playerController);
        }

        return null;
    }
}
