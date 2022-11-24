using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 触れたら遅くする
/// </summary>

public class TrapSpeedDown : ItemBase
{
    [Tooltip("アイテムを取ったら設定されるスピード"),SerializeField]
    float _setSpeed = 10f;
    [Tooltip("アイテムの効果時間"),SerializeField]
    float _duration = 1.0f;

    float _saveSpeed = 5.0f;
    PlayerController _player;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj)
        {
            _player = playerObj.GetComponent<PlayerController>();
            if (_player)
            {
                Debug.Log("SetSpeed");
                _saveSpeed = _player.DefaultSpeed;
                _player.SetSpeed = _setSpeed;
                StartCoroutine(DurationItem());
            }
        }
    }

    IEnumerator DurationItem()
    {
        Debug.Log("RisetSpeed");
        yield return new WaitForSeconds(_duration);
        _player.SetSpeed = _saveSpeed;
    }
}
