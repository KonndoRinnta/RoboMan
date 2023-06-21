using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        Vector2 direction = playerController.Rb.velocity.normalized;
        playerController.Rb.velocity = direction * playerController.DashPower;
        yield return new WaitForSeconds(playerController.DashTime); // �X�����I���܂ő҂�
        playerController.SlidingChecker();
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_sliding");
        playerController.StartCoroutine(Execute(playerController)); // Coroutine���J�n����
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
    public void OnEnd(PlayerController playerController)
    {

    }
}
