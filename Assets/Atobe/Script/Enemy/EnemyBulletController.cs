using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を制御するコンポーネント
/// 出現時のプレイヤーの位置を検出して、その方向に進む
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour
{
    [Tooltip("発射する弾のスピード"),SerializeField]
    float _speed = 3f;
    [Tooltip("攻撃力"),SerializeField]
    int _damage = 1;
    void Start()
    {
        // 速度ベクトルを求める
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * _speed;

            // 速度ベクトルをセットする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            // プレイヤーが居なかったら、すぐ消してしまう
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.Damage(_damage);
        }
    }
}
