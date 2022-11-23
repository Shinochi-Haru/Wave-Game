using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �擾����Ǝc�e����������A�C�e��
/// </summary>

public class BulletPlus : ItemBase
{
    [Header("�ǉ�����c�e��")]
    [SerializeField] int _bullet = 1;
    TestPlayerController _player;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj)
        {
            Debug.Log("�e���ǉ�");
            _player = playerObj.GetComponent<TestPlayerController>();
            _player.UpdateBullet(_bullet);
        }
        Destroy(this.gameObject);
    }
}
