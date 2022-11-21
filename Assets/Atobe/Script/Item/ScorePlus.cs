using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �擾����ƃX�R�A�����Z�����A�C�e��
/// </summary>

public class ScorePlus : ItemBase
{
    [Header("���Z���链�_")]
    [SerializeField] int _point = 1000;
    
    ScoreManager _scoreManager;
    public override void Activate()
    {
        Debug.Log("Active");
        var scoreManager = GameObject.Find("ScoreManager");

        if (scoreManager)
        {
            Debug.Log("�X�R�A�ǉ�");
            _scoreManager = scoreManager.GetComponent<ScoreManager>();
            _scoreManager.UpdateScore(_point);
        }
        Destroy(gameObject);
    }
}
