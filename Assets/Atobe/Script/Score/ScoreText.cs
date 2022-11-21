using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [Tooltip("スコアを表示するテキスト")]
    [SerializeField] Text _scoreText;
    void Update()
    {
        _scoreText.text = "Score :" + ScoreManager.Score.ToString("D10");
    }
}
