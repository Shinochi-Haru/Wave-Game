using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed = 1.0f;
    [Header("�v���C���[�̗̑�")]
    [SerializeField] int _hp = 3;

    // �v���C���[�� Rigidbody
    Rigidbody2D _rb = default;
    // ���������̓��͒l
    float _hori;
    // ���������̓��͒l
    float _vert;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }

    void Start()
    {
        HpMax = _hp;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _hori = Input.GetAxisRaw("Horizontal");
        _vert = Input.GetAxisRaw("Vertical");

        if (Hp < 1)
        {
            Debug.Log("GameOver");
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector2.right * _hori * _speed, ForceMode2D.Force);
        _rb.AddForce(Vector2.up * _vert * _speed, ForceMode2D.Force);
    }
}
