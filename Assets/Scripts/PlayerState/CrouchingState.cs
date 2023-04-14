using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {

    }
    public void OnUpdate(PlayerController playerController)
    {
        if (Input.GetButtonUp("Crouching"))
        {
            playerController.ChangeState(PlayerState.Stop);
        }
        if (Input.GetButtonDown("Sliding"))
        {
            playerController.ChangeState(PlayerState.Sliding);
        }
    }
}
