using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Y方向へ移動させるコンポーネント
/// 壁にぶつかると反転
/// </summary>

public class EnemyMoveY : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    Vector2 _lineForWall = Vector2.down;
    [SerializeField] LayerMask _wallLayer = 0;
    Vector2 _moveDirection = Vector2.down;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveWithTurn();
    }

    void MoveWithTurn()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;


        if (hit.collider)
        {
            Debug.Log("Hit");
            _lineForWall *= -1;
            _moveDirection *= -1;
        }

        velo = _moveDirection.normalized * _speed;
        velo.x = _rb.velocity.x;
        _rb.velocity = velo;
    }
}
