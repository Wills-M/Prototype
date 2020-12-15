using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController playerController;

    public PlayerState(PlayerController pc)
    {
        playerController = pc;
    }

    public abstract PlayerState Tick();

    public abstract void Enter();

    public abstract void Leave();
}
