using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("palyer_air");
    }
    public void OnUpdate(PlayerController playerController)
    {
        float horizontalInput = playerController.MoveInput;

        Vector2 movement = new Vector2(horizontalInput * playerController.Speed, playerController.Rb.velocity.y - 0.1f);

        playerController.Rb.velocity = movement;
        if (playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Stop);
        }
    }
}
