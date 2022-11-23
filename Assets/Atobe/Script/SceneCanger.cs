using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// シーンのロード用
/// </summary>

public class SceneCanger : MonoBehaviour
{
    ScoreManager _scoreManager;
    int _num = 0;

    /// <summary>
    /// シーンのロード用関数
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// ゲーム開始時に呼ぶ関数
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
