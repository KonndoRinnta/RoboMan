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
        yield return new WaitForSeconds(_slidingTime); // �X���C�f�B���O���I���܂ő҂�
        playerController.ChangeState(PlayerState.Stop);
    }
    public void OnStart(PlayerController playerController)
    {
        
    }
    public void OnUpdate(PlayerController playerController)
    {
        playerController.StartCoroutine(Execute(playerController)); // Coroutine���J�n����
    }
}
