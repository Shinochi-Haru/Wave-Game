using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyの基底クラス
/// </summary>

public class EnemyController : MonoBehaviour
{
    [Header("Enemyの体力")]
    [SerializeField] int _hp = 1;
    [Header("得点")]
    [SerializeField] int _point = 1000;
    [Header("攻撃力")]
    [SerializeField] int _damage = 1;

    private TestPlayerController _player;
    private ScoreManager _scoreManager;

    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<TestPlayerController>();
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
            Debug.Log("ぐはっっ");
        }
        /*if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.Damage(_damage);
        }*/
    }

    /// <summary>
    /// EnemyのHpが0になった時に呼ばれる関数
    /// </summary>
    void EnemyDead()
    {
        _scoreManager.UpdateScore(_point);
        Destroy(this.gameObject);
    }
}
