using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialNextPage : MonoBehaviour
{
    [SerializeField, Header("現在のパネル")]
    private GameObject _currentPanel;

    [SerializeField, Header("移行するパネル")]
    private GameObject _nextPanel;

    [SerializeField, Header("初期選択ボタン")]
    private GameObject _firstSelectButton;
    public void ChangePanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_firstSelectButton);

        _nextPanel.gameObject.SetActive(true);
        _currentPanel.gameObject.SetActive(false);
    }
}
