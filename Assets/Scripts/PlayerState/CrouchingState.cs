using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingState : IPlayerState
{
    public void OnUpdate(PlayerController playerController)
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerController.ChangeState(PlayerState.Stop);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerController.ChangeState(PlayerState.Sliding);
        }
    }
}
