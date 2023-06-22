using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.velocity = direction * playerController.DashPower;
        yield return new WaitForSeconds(playerController.DashTime); // ダッシュが終わるまで待つ
        playerController.DashChecker();
        playerController.InputAble();
        if (playerController.IsGround) playerController.ChangeState(PlayerState.Stop);
        else if(playerController.AirDashable)
        {
            playerController.AirDashChecker();
            playerController.ChangeState(PlayerState.Air);
        }
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.StartCoroutine(Execute(playerController)); // Coroutineを開始する
        playerController.Animator.Play("player_dash");
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
    public void OnEnd(PlayerController playerController)
    {

    }
}
