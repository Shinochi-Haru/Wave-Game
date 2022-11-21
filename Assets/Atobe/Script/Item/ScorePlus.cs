using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得するとスコアが加算されるアイテム
/// </summary>

public class ScorePlus : ItemBase
{
    [Header("加算する得点")]
    [SerializeField] int _point = 1000;
    
    ScoreManager _scoreManager;
    public override void Activate()
    {
        Debug.Log("Active");
        var scoreManager = GameObject.Find("ScoreManager");

        if (scoreManager)
        {
            Debug.Log("スコア追加");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.UpdateScore(_point);
        }
        Destroy(gameObject);
    }
}
