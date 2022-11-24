using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Tooltip("")]
    [SerializeField] float _lifetime = 2;
    private Vector3 m_velocity; // ���x
    private void Update()
    {
        // �ړ�����
        transform.localPosition += m_velocity;
    }

    // �e�𔭎˂��鎞�ɏ��������邽�߂̊֐�
    public void Init(float angle, float speed)
    {
        // �e�̔��ˊp�x���x�N�g���ɕϊ�����
        var direction = Utils.GetDirection(angle);

        // ���ˊp�x�Ƒ������瑬�x�����߂�
        m_velocity = direction * speed;

        // �e���i�s�����������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;
        Destroy(gameObject, _lifetime);
    }
}
