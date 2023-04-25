using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.velocity = direction * playerController.DashPower;
        yield return new WaitForSeconds(playerController.DashTime); // ダッシュが終わるまで待つ
        playerController.DashChecker();
        if (playerController.IsGround) playerController.ChangeState(PlayerState.Stop);
        else if(playerController.AirDashable)
        {
            playerController.AirDashChecker();
            playerController.ChangeState(PlayerState.Air);
        }
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_dash");
        playerController.StartCoroutine(Execute(playerController)); // Coroutineを開始する
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
}
