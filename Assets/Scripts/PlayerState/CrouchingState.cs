using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_crouching");
    }
    public void OnUpdate(PlayerController playerController)
    {
        if (!playerController.CrouchingInput)
        {
            playerController.ChangeState(PlayerState.Stop);
        }
        if (playerController.SlidingInput)
        {
            playerController.ChangeState(PlayerState.Sliding);
        }
    }
}
