using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttackState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        playerController.NormalAttackCheckOn();
        yield return new WaitForSeconds(playerController.AttackTime);
        playerController.NormalAttackCheckOff();
        playerController.InputAble();
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_air_atk");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerMove)
    {

    }
}
