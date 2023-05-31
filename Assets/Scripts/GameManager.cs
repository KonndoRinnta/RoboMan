using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーのパネル")]
    GameObject _gameOverPanel;

    private int _enemyKillCount;

    private bool _gameOver;
    public void IsGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }
}
