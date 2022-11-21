using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// シーンのロード用
/// </summary>

public class SceneCanger : MonoBehaviour
{
    [Header("読み込みたいシーンの名前")]
    [SerializeField] string _sceneName;

    ScoreManager _scoreManager;
    int _num = 0;
    /// <summary>
    /// シーンのロード用関数
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
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
            Debug.Log("スコア追加");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.StartGame(_num);
        }
    }
}
