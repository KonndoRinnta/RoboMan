using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    [Header("���[�h�������V�[���̖��O")]
    string _loadSceneName;

    public void SceneLoad()
    {
        SceneManager.LoadScene(_loadSceneName);
    }
}