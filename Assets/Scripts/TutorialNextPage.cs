using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNextPage : MonoBehaviour
{
    [SerializeField, Header("���݂̃p�l��")]
    private GameObject _currentPanel;

    [SerializeField, Header("�ڍs����p�l��")]
    private GameObject _nextPanel;
    public void ChangePanel()
    {
        _nextPanel.gameObject.SetActive(true);
        _currentPanel.gameObject.SetActive(false);
    }
}
