using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(PlayerController playerController) : base(playerController)
    {
        this.playerController = playerController;
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
                return new RunningPlayerState(playerController, hit.point);
            }
        }

        return null;
    }
}
