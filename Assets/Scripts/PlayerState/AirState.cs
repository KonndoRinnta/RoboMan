using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_air");
    }
    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.MoveInput != 0f)
        {
            playerController.ChangeState(PlayerState.AirWalk);
        }

        if (playerController.AttackInput)
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
        if(playerController.transform.position.y <= -10)
        {
            playerController.ChangeState(PlayerState.GameOver);
        }
    }
}
