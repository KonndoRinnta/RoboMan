using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.NormalAttackCheckOn();
        yield return new WaitForSeconds(playerController.AttackTime);
        playerController.NormalAttackCheckOff();
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_normalattack");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerMove)
    {

    }
}
