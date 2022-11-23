using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// �V�[���̃��[�h�p
/// </summary>

public class SceneCanger : MonoBehaviour
{
    ScoreManager _scoreManager;
    int _num = 0;

    /// <summary>
    /// �V�[���̃��[�h�p�֐�
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// �Q�[���J�n���ɌĂԊ֐�
    /// </summary>
    public void StartGame()
    {
        Debug.Log("Reset");
        var scoreManager = GameObject.Find("ScoreManager");

        if (scoreManager)
        {
            Debug.Log("ScoreRiset");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.StartGame(_num);
        }
    }
}
