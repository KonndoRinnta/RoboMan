using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_walk");
    }
    public void OnUpdate(PlayerController playerController)
    {
        float horizontalInput = playerController.MoveInput;

        Vector2 movement = new Vector2(horizontalInput * playerController.Speed, 0f);

        playerController.Rb.velocity = movement;
        if (playerController.DashInput)
        {
            playerController.ChangeState(PlayerState.Dash);
        }

        if (playerController.AttackInput)
        {
            playerController.ChangeState(PlayerState.WalkAttack);
        }

        if (playerController.MoveInput == 0f)
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

        if (playerController.CrouchingInput)
        {
            playerController.ChangeState(PlayerState.Crouching);
        }
    }
}
