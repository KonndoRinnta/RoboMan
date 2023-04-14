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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerController.ChangeState(PlayerState.Dash);
        }
        if(Input.GetButtonUp("Horizontal"))
        {
            playerController.ChangeState(PlayerState.Stop);
        }

        if(playerController.IsGround == false)
        {
            playerController.ChangeState(PlayerState.Air);
        }

        if (Input.GetButtonDown("Jump"))
        {
            playerController.ChangeState(PlayerState.Jump);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}
