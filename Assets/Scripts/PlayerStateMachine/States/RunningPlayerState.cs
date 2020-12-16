using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerState : PlayerState
{
    public RunningPlayerState(PlayerController playerController) : base(playerController)
    {
        this.playerController = playerController;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                playerController.transform.LookAt(hit.point, Vector3.up);
                return new RollingPlayerState(playerController, hit.point);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                playerController.transform.LookAt(hit.point, Vector3.up);
                playerController.navMeshAgent.destination = hit.point;
            }
        }

        if (playerController.navMeshAgent.remainingDistance <= playerController.navMeshAgent.stoppingDistance)
        {
            return new IdlePlayerState(playerController);
        }

        return null;
    }
}
