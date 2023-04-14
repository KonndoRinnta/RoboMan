using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void OnStart(PlayerController playerController);
    void OnUpdate(PlayerController playerController);
}