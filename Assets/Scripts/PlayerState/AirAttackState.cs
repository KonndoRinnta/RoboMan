using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttackState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        playerController.AirAttackColliderOn();
        yield return new WaitForSeconds(playerController.AttackTime);
        playerController.AirAttackClliderOff();
        playerController.InputAble();
        playerController.AttackInputDisAble();
        playerController.ChangeState(PlayerState.Air);  
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_air_atk");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerController)
    {
        if(playerController.IsGround)
        {
            playerController.ChangeState(PlayerState.Stop);
        }
    }
    public void OnEnd(PlayerController playerController)
    {

    }
}
