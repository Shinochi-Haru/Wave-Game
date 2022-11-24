using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy�̊��N���X
/// </summary>

public class EnemyController : MonoBehaviour
{
    [Tooltip("Enemy�̗̑�"),SerializeField]
    int _hp = 1;
    [Tooltip("���_"),SerializeField]
    int _point = 1000;
    [Tooltip("�U����"),SerializeField]
    int _damage = 1;

    private PlayerController _player;
    private ScoreManager _scoreManager;

    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Hp < 1)
        {
            EnemyDead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
            Debug.Log("���͂���");
        }
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.Damage(_damage);
        }
    }

    /// <summary>
    /// Enemy��Hp��0�ɂȂ������ɌĂ΂��֐�
    /// </summary>
    void EnemyDead()
    {
        _scoreManager.UpdateScore(_point);
        Destroy(this.gameObject);
    }
}
