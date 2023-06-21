using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearState : IPlayerState
{
    public IEnumerator Execute(PlayerController playerController)
    {
        playerController.InputDisable();
        yield return new WaitForSeconds(playerController.GameClearAnimTime);
        playerController.GM.IsGameClear();
        playerController.PlayerDisable();
    }
    public void OnStart(PlayerController playerController)
    {
        playerController.Animator.Play("player_gameclear");
        playerController.StartCoroutine(Execute(playerController));
    }
    public void OnUpdate(PlayerController playerController)
    {
        
    }
    public void OnEnd(PlayerController playerController)
    {

    }
}
