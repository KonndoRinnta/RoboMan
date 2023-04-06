using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerState
{
    public void OnUpdate(PlayerController playerController)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput * playerController.Speed, 0f);

        playerController.Rb.velocity = movement;
        if(Input.GetButtonUp("Horizontal"))
        {
            playerController.ChangeState(PlayerState.Stop);
        }
    }
}
