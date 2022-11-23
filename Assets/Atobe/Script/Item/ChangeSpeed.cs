using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得すると移動速度が変わるアイテム
/// </summary>

public class ChangeSpeed : ItemBase
{
    [Header("アイテムを取ったら設定されるスピード")]
    [SerializeField] float _setSpeed = 10f;
    [Header("アイテムの効果時間")]
    [SerializeField] float _duration = 1.0f;

    float _saveSpeed = 5.0f;
    int _count = 0;
    PlayerController _player;
    SpriteRenderer _sprite;
    public override void Activate()
    {
        if (_count < 1)
        {
            Debug.Log("Active");
            _sprite = GetComponent<SpriteRenderer>();
            _sprite.enabled = false;
            var playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj)
            {
                _player = playerObj.GetComponent<PlayerController>();
                if (_player)
                {
                    _count++;
                    Debug.Log("SetSpeed");
                    _saveSpeed = _player.DefaultSpeed;
                    _player.SetSpeed = _setSpeed;
                    StartCoroutine(DurationItem());
                }
            }
        }
    }

    IEnumerator DurationItem() 
    {
        yield return new WaitForSeconds(_duration);
        _player.SetSpeed = _saveSpeed;
        Destroy();
    }
}
