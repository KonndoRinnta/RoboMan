using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerState
{
    public void OnUpdate(PlayerController playerController)
    {
        if(playerController.IsGround)
        {
            
        }
        playerController.ChangeState(PlayerState.Air);
    }
}
