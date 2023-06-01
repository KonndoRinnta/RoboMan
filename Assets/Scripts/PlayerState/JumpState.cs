using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerState
{
    private float _jumpTime = 0.06f;
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.Rb.AddForce(new Vector2(0, playerController.JumpPower), ForceMode2D.Impulse);
        yield return new WaitForSeconds(_jumpTime); // ジャンプが終わるまで待つ
        playerController.ChangeState(PlayerState.Air);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.StartCoroutine(Execute(playerController)); // Coroutineを開始する
        playerController.Animator.Play("player_jump");
    }

    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.IsDamege)
        {
            playerController.ChangeState(PlayerState.Damege);
        }
        if (playerController.AttackInput)
        {
            playerController.ChangeState(PlayerState.AirAttack);
        }
    }
}
