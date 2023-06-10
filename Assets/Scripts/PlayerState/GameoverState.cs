using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        playerController.FreezePosition();
        yield return new WaitForSeconds(playerController.GameOverAnimTime);
        playerController.PlayerDisable();
        playerController.GM.IsGameOver();
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_gameover");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
}
