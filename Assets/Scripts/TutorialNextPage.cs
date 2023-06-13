using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNextPage : MonoBehaviour
{
    [SerializeField, Header("現在のパネル")]
    private GameObject _currentPanel;

    [SerializeField, Header("移行するパネル")]
    private GameObject _nextPanel;
    public void ChangePanel()
    {
        _nextPanel.gameObject.SetActive(true);
        _currentPanel.gameObject.SetActive(false);
    }
}
