using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_air");
    }
    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.MoveInput != 0f)
        {
            playerController.ChangeState(PlayerState.AirWalk);
        }

        if (playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Stop);
        }
    }
}
