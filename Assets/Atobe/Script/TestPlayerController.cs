using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度"),SerializeField]
    float _speed = 1.0f;
    public float Speed => _speed;

    [Tooltip("プレイヤーの体力"),SerializeField]
    int _hp = 3;
    [Tooltip("残弾数"),SerializeField]
    int _bullet = 5;

    // プレイヤーの Rigidbody
    Rigidbody2D _rb = default;
    // 水平方向の入力値
    float _hori;
    // 垂直方向の入力値
    float _vert;

    SceneCanger sceneCanger;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float DefaultSpeed { get; private set; }
    public float SetSpeed { set { _speed = value; } }

    void Start()
    {
        HpMax = _hp;
        DefaultSpeed = _speed;
        _rb = GetComponent<Rigidbody2D>();
        sceneCanger = GetComponent<SceneCanger>();
    }

    void Update()
    {
        _hori = Input.GetAxisRaw("Horizontal");
        _vert = Input.GetAxisRaw("Vertical");

        if (Hp < 1)
        {
            Debug.Log("GameOver");
            sceneCanger.LoadScene("Result");
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector2.right * _hori * _speed, ForceMode2D.Force);
        _rb.AddForce(Vector2.up * _vert * _speed, ForceMode2D.Force);
    }

    /// <summary>
    /// 残弾数を追加する用の関数
    /// </summary>
    /// <param name="bullet"></param>
    public void UpdateBullet(int bullet)
    {
        _bullet += bullet;
    }

    /// <summary>
    /// Playerがダメージを食らった時用の関数
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        Hp -= damage;
    }
}

