using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得すると残弾数が増えるアイテム
/// </summary>

public class BulletPlus : ItemBase
{
    [Tooltip("追加する残弾数"),SerializeField]
    int _bullet = 1;

    PlayerAttackController _player;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.Find("Player");
        
        if (playerObj)
        {
            Debug.Log("弾数追加");
            _player = playerObj.GetComponent<PlayerAttackController>();
            _player.UpdateBullet(_bullet);
        }
        Destroy(this.gameObject);
    }
}
