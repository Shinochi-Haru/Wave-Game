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

    private TestPlayerController _player;

    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<TestPlayerController>();
    }

    void Update()
    {
        if (_hp < 1)
        {
            //GameManager.Score += _point;
            Destroy(gameObject,0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
    }
}
