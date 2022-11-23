using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得すると残弾数が増えるアイテム
/// </summary>

public class BulletPlus : ItemBase
{
    [Header("追加する残弾数")]
    [SerializeField] int _bullet = 1;
    TestPlayerController _player;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj)
        {
            Debug.Log("弾数追加");
            _player = playerObj.GetComponent<TestPlayerController>();
            _player.UpdateBullet(_bullet);
        }
        Destroy(this.gameObject);
    }
}
