using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�𐧌䂷��R���|�[�l���g
/// �o�����̃v���C���[�̈ʒu�����o���āA���̕����ɐi��
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour
{
    [Tooltip("���˂���e�̃X�s�[�h"),SerializeField]
    float _speed = 3f;
    [Tooltip("�U����"),SerializeField]
    int _damage = 1;
    void Start()
    {
        // ���x�x�N�g�������߂�
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * _speed;

            // ���x�x�N�g�����Z�b�g����
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            // �v���C���[�����Ȃ�������A���������Ă��܂�
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
