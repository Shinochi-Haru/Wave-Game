using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �擾����Ǝc�e����������A�C�e��
/// </summary>

public class BulletPlus : ItemBase
{
    [Tooltip("�ǉ�����c�e��"),SerializeField]
    int _bullet = 1;

    PlayerAttackController _player;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.Find("Player");
        
        if (playerObj)
        {
            Debug.Log("�e���ǉ�");
            _player = playerObj.GetComponent<PlayerAttackController>();
            _player.UpdateBullet(_bullet);
        }
        Destroy(this.gameObject);
    }
}
