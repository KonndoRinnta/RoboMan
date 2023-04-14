using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IPlayerState
{
    private float _dashTime = 0.06f;
    public IEnumerator Execute(PlayerController playerController)
    {
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.AddForce(direction * playerController.Dash, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_dashTime); // ダッシュが終わるまで待つ
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {

    }
    public void OnUpdate(PlayerController playerController)
    {
        playerController.StartCoroutine(Execute(playerController)); // Coroutineを開始する
    }
}
