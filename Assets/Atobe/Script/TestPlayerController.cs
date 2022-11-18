using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [Header("プレイヤーの移動速度")]
    [SerializeField] float _speed = 1.0f;
    [Header("プレイヤーの体力")]
    [SerializeField] int _hp = 3;

    // プレイヤーの Rigidbody
    Rigidbody2D _rb = default;
    // 水平方向の入力値
    float _hori;
    // 垂直方向の入力値
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
