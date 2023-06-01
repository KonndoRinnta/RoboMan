using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAtkState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        playerController.WalkAttackCheckOn();
        yield return new WaitForSeconds(playerController.AttackTime);
        playerController.WalkAttackCheckOff();
        playerController.InputAble();
        playerController.AttackInputDisAble();
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_walk_atk");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
}
