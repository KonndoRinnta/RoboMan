using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StopState : IPlayerState
{
    

    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_stand");
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
        if(Input.GetButtonDown("Crouching"))
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}