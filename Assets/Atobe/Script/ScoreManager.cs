using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�R�A�̊Ǘ�
/// </summary>

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _manager;
    private static int _score;

    public static int Score { get => _score; private set => _score = value; }
    public static ScoreManager Instance { get => _manager; private set => _manager = value; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// �Q�[���J�n���ɌĂԊ֐�
    /// </summary>
    public void StartGame(int num)
    {
        Debug.Log("Reset");
        Score = num;
    }

    /// <summary>
    /// �X�R�A���Z�p�֐�
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        Score += score;
    }
}
