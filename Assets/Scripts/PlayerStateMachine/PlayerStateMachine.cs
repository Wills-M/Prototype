using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerState playerState;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        ChangeState(new IdlePlayerState(playerController));
    }

    private void ChangeState(PlayerState newState)
    {
        playerState?.Leave();
        playerState = newState;
        playerState.Enter();
    }

    private void Update()
    {
        PlayerState newState = playerState?.Tick();

        if (newState != null)
        {
            ChangeState(newState);
        }
    }
}
