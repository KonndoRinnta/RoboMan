using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_stand");
    }
    public void OnUpdate(PlayerController playerController)
    {
        if(Input.GetButton("Horizontal"))
        {
            playerController.ChangeState(PlayerState.Walk);
        }
        if(Input.GetButtonDown("Jump"))
        {
            playerController.ChangeState(PlayerState.Jump);
        }
        if(Input.GetButtonDown("Crouching"))
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}