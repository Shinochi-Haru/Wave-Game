using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// �V�[���̃��[�h�p
/// </summary>

public class SceneCanger : MonoBehaviour
{
    [Header("�ǂݍ��݂����V�[���̖��O")]
    [SerializeField] string _sceneName;

    ScoreManager _scoreManager;
    int _num = 0;
    /// <summary>
    /// �V�[���̃��[�h�p�֐�
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
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
            Debug.Log("�X�R�A�ǉ�");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.StartGame(_num);
        }
    }
}
