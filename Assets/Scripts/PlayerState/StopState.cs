using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : IPlayerState
{
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
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}