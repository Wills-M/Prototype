using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerState : PlayerState
{
    public RunningPlayerState(PlayerController pc) : base(pc)
    {
        playerController = pc;
    }

    public override void Enter()
    {
        playerController.animator.SetTrigger("Running");
    }

    public override void Leave()
    {

    }

    public override PlayerState Tick()
    {
        playerController.HandleInput();

        if (playerController.navMeshAgent.remainingDistance <= playerController.navMeshAgent.stoppingDistance)
        {
            return new IdlePlayerState(playerController);
        }

        return null;
    }
}
