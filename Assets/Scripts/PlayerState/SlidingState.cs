using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : IPlayerState
{
    private float _slidingTime = 0.06f;
    public IEnumerator Execute(PlayerController playerController)
    {
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.AddForce(direction * playerController.Dash, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_slidingTime); // スライディングが終わるまで待つ
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_sliding");
        playerController.StartCoroutine(Execute(playerController)); // Coroutineを開始する
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
}
