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

    public void LoadScene(string v)
    {
        SceneManager.LoadScene(v);
    }

    public void StartGame(int num)
    {
        var scoreManager = GameObject.Find("ScoreManager");

        if (scoreManager)
        {
            Debug.Log("�X�R�A�ǉ�");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.ResetScore(num);
        }
    }
}
