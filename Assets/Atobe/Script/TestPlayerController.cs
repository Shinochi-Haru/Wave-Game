using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[�̈ړ����x"),SerializeField]
    float _speed = 1.0f;
    public float Speed => _speed;

    [Tooltip("�v���C���[�̗̑�"),SerializeField]
    int _hp = 3;
    [Tooltip("�c�e��"),SerializeField]
    int _bullet = 5;

    // �v���C���[�� Rigidbody
    Rigidbody2D _rb = default;
    // ���������̓��͒l
    float _hori;
    // ���������̓��͒l
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
    /// �c�e����ǉ�����p�̊֐�
    /// </summary>
    /// <param name="bullet"></param>
    public void UpdateBullet(int bullet)
    {
        _bullet += bullet;
    }

    /// <summary>
    /// Player���_���[�W��H��������p�̊֐�
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        Hp -= damage;
    }
}

