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
    [SceneName,SerializeField]
    private string _nextScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(_nextScene);
    }
    public void LoadScene(string v)
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void StartGame
        (int num)
    {
        var scoreManager = GameObject.Find("ScoreManager");

        if (scoreManager)
        {
            Debug.Log("スコア追加");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.ResetScore(num);
        }
    }
}
