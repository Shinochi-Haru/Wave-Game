using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    private Vector2 _dir;
    [SerializeField]private Vector2 _movePower;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] BulletController _bulletPrefab = null;
    [SerializeField] float _shotTimer;
    [SerializeField] float _bulletSpeed = 10f;
    private float _shotAngleRange;
    [SerializeField] int _shotCount; // �e�̔��ː�
    [SerializeField] float _shotInterval; // �e�̔��ˊԊu�i�b�j
    [SerializeField]private int _speed;
    [SerializeField] int _bulletCount = 0;

    public int Speed { get { return _speed; } set { _speed = value; } }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   
        float v = Input.GetAxisRaw("Vertical");     
        Vector2 dir = new Vector2(h, v).normalized;  
        _rb.velocity = dir * _movePower;        

        // �v���C���[�̃X�N���[�����W���v�Z����
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // �v���C���[���猩���}�E�X�J�[�\���̕������v�Z����
        var direction = Input.mousePosition - screenPos;

        // �}�E�X�J�[�\�������݂�������̊p�x���擾����
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // �v���C���[���}�E�X�J�[�\���̕���������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[���X�V����
        _shotTimer += Time.deltaTime;

        _shotTimer = 0;// �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g����

        // �e�𔭎˂���
        if (Input.GetButtonDown("Fire1"))
        {
            Fire(angle, _bulletSpeed, _shotCount);
            _bulletCount++;
        }  
    }

    // �e�𔭎˂���֐�
    void Fire(float angleBase, float speed, int count)
    {
        var rot = transform.localRotation; // �v���C���[�̌���
        // �e�� 1 �������˂���ꍇ
        if (1 == count && 5 > _bulletCount)
        {
            // ���˂���e�𐶐�����
            var fire = Instantiate(_bulletPrefab, _muzzle.position, rot);

            // �e�𔭎˂�������Ƒ�����ݒ肷��
            fire.Init(angleBase, speed);
        }
    }

    
}
