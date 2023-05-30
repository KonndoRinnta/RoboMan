using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.velocity = direction * 3;
        playerController.Damage();
        yield return new WaitForSeconds(playerController.DamageInvincibleTime);
        playerController.InputAble();
        playerController.IsDamegeDisable();
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_damage");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
}
