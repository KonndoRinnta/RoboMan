using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {

    }
    public void OnUpdate(PlayerController playerController)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput * playerController.Speed, 0f);

        playerController.Rb.velocity = movement;
        if (Input.GetButtonDown("Dash"))
        {
            playerController.ChangeState(PlayerState.Dash);
        }
        if(playerController.MoveInput == 0f)
        {
            playerController.ChangeState(PlayerState.Stop);
        }

        if(playerController.IsGround == false)
        {
            playerController.ChangeState(PlayerState.Air);
        }

        if (playerController.JumpInput)
        {
            playerController.ChangeState(PlayerState.Jump);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}
