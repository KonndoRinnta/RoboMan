using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IPlayerState
{
    public void OnStart(PlayerController playerController)
    {
        playerController.FreezePosition();
    }
    public void OnUpdate(PlayerController playerController)
    {

    }
    public void OnEnd(PlayerController playerController)
    {
        playerController.FreezePositionRemove();
        playerController.Rb.AddForce(new Vector2(0,-0.1f),ForceMode2D.Impulse);
    }
}
