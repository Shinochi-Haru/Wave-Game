using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpeedDown : ItemBase
{
    [Header("�A�C�e�����������ݒ肳���X�s�[�h")]
    [SerializeField] float _setSpeed = 10f;
    [Header("�A�C�e���̌��ʎ���")]
    [SerializeField] float _duration = 1.0f;

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
