using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーのパネル")]
    GameObject _gameOverPanel;

    [SerializeField, Header("ゲームクリアのパネル")]
    GameObject _gameClearPanel;

    [SerializeField, Header("ゲームオーバー時の初期配置ボタン")]
    GameObject _gameOverFirstButton;

    [SerializeField, Header("ゲームクリア時の初期配置ボタン")]
    GameObject _gameClearFirstButton;

    private int _enemyKillCount;
    public int EnemyKillCount => _enemyKillCount;

    private bool _gameOver;
    public void IsGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_gameOverFirstButton);
    }
    public void IsGameClear()
    {
        _gameClearPanel.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_gameClearFirstButton);
    }
    public void KillCount()
    {
        Debug.Log("p");
        _enemyKillCount++;
    }
}
