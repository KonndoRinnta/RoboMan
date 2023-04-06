using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : IPlayerState
{
    public void OnUpdate(PlayerController playerController)
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            playerController.ChangeState(PlayerState.Walk);
        }
    }
}
