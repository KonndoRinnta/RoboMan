using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StopState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_stand");
        playerController.DashChecker();
    }

    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.MoveInput != 0f)
        {
            playerController.ChangeState(PlayerState.Walk);
        }

        if(playerController.JumpInput)
        {
            playerController.ChangeState(PlayerState.Jump);
        }

        if(playerController.CrouchingInput)
        {
            playerController.ChangeState(PlayerState.Crouching);
        }

        if (!playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Air);
        }
    }
}