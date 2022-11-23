using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy‚ÌŠî’êƒNƒ‰ƒX
/// </summary>

public class EnemyController : MonoBehaviour
{
    [Header("Enemy‚Ì‘Ì—Í")]
    [SerializeField] int _hp = 1;
    [Header("“¾“_")]
    [SerializeField] int _point = 1000;
    [Header("UŒ‚—Í")]
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
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        /*if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.Damage(_damage);
        }*/
    }

    /// <summary>
    /// Enemy‚ÌHp‚ª0‚É‚È‚Á‚½‚ÉŒÄ‚Î‚ê‚éŠÖ”
    /// </summary>
    void EnemyDead()
    {
        _scoreManager.UpdateScore(_point);
        Destroy(this.gameObject);
    }
}
