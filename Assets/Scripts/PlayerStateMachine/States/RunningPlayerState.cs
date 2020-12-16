using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerState : PlayerState
{
    private Vector3 hitpoint;

    public RunningPlayerState(PlayerController playerController, Vector3 hitpoint) : base(playerController)
    {
        this.playerController = playerController;
        this.hitpoint = hitpoint;
    }

    public override void Enter()
    {
        playerController.animator.SetTrigger("Running");
        playerController.transform.LookAt(hitpoint, Vector3.up);
        playerController.navMeshAgent.destination = hitpoint;
    }

    public override void Leave()
    {

    }

    public override PlayerState Tick()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                return new RollingPlayerState(playerController, hit.point);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                hitpoint = hit.point;
                playerController.transform.LookAt(hitpoint, Vector3.up);
                playerController.navMeshAgent.destination = hitpoint;
            }
        }

        if (playerController.navMeshAgent.remainingDistance <= playerController.navMeshAgent.stoppingDistance)
        {
            return new IdlePlayerState(playerController);
        }

        return null;
    }
}
