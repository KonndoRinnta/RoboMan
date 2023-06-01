using System.Collections;
using UnityEngine;

public class DamageState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.velocity = direction * 3;
        playerController.Damage();
        if (playerController.HP <= 0) playerController.ChangeState(PlayerState.GameOver);
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
