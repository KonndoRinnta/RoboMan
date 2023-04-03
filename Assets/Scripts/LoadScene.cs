using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    [Header("ロードしたいシーンの名前")]
    string _loadSceneName;

    public void SceneLoad()
    {
        SceneManager.LoadScene(_loadSceneName);
    }
}
