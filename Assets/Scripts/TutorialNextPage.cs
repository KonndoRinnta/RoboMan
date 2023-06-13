using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialNextPage : MonoBehaviour
{
    [SerializeField, Header("���݂̃p�l��")]
    private GameObject _currentPanel;

    [SerializeField, Header("�ڍs����p�l��")]
    private GameObject _nextPanel;

    [SerializeField, Header("�����I���{�^��")]
    private GameObject _firstSelectButton;
    public void ChangePanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_firstSelectButton);

        _nextPanel.gameObject.SetActive(true);
        _currentPanel.gameObject.SetActive(false);
    }
}
