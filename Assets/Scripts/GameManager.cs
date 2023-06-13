using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("�Q�[���I�[�o�[�̃p�l��")]
    GameObject _gameOverPanel;

    [SerializeField, Header("�Q�[���N���A�̃p�l��")]
    GameObject _gameClearPanel;

    [SerializeField, Header("�Q�[���I�[�o�[���̏����z�u�{�^��")]
    GameObject _gameOverFirstButton;

    [SerializeField, Header("�Q�[���N���A���̏����z�u�{�^��")]
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
