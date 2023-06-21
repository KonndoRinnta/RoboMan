using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StopState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.Rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        playerController.Rb.constraints = RigidbodyConstraints2D.None;
        playerController.Rb.freezeRotation = true;
        playerController.Animator.Play("player_stand");
        playerController.AirDashRemove();
    }

    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.MoveInput != 0f)
        {
            playerController.ChangeState(PlayerState.Walk);
        }

        if(playerController.JumpInput)
        {
            playerController.ChangeState(PlayerState.Jump);
        }

        if(playerController.CrouchingInput)
        {
            playerController.ChangeState(PlayerState.Crouching);
        }

        if (playerController.AttackInput)
        {
            playerController.ChangeState(PlayerState.NormalAttack);
        }

        if (!playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Air);
        }
        if (playerController.IsDamege)
        {
            playerController.ChangeState(PlayerState.Damege);
        }
    }
    public void OnEnd(PlayerController playerController)
    {

    }
}