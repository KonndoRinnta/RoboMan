using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWalkState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_air");
    }

    public void OnUpdate(PlayerController playerController)
    {
        float horizontalInput = playerController.MoveInput;

        Vector2 movement = new Vector2(horizontalInput * playerController.Speed, playerController.Rb.velocity.y - 0.1f);

        playerController.Rb.velocity = movement;

        if (playerController.MoveInput == 0f)
        {
            playerController.ChangeState(PlayerState.Air);
        }

        if (playerController.DashInput && playerController.AirDashable)
        {
            playerController.ChangeState(PlayerState.Dash);
        }

        if(playerController.AttackInput && playerController.AirAtkAble)
        {
            playerController.ChangeState(PlayerState.AirAttack);
        }

        if (playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Stop);
        }

        if (playerController.IsDamege)
        {
            playerController.ChangeState(PlayerState.Damege);
        }
    }
}
