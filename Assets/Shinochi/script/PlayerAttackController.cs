using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] BulletController _bulletPrefab = null;
    [SerializeField] float _bulletSpeed = 10f;
    [SerializeField] int _shotCount; // �e�̔��ː�
    [SerializeField] int _bulletCount = 0;
    [SerializeField] Text _text;
    Animator _anim;

    PlayerController _player;

    [SerializeField] GameObject _topGun;
    [SerializeField] GameObject _backGun;
    [SerializeField] GameObject _leftGun;
    [SerializeField] GameObject _rightGun;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.color = Color.black;
        _text.text = "X " + _bulletCount.ToString("D3");
        if (_bulletCount < 1)
        {
            _text.color = Color.red;
        }

        // �v���C���[�̃X�N���[�����W���v�Z����
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // �v���C���[���猩���}�E�X�J�[�\���̕������v�Z����
        var direction = Input.mousePosition - screenPos;

        // �}�E�X�J�[�\�������݂�������̊p�x���擾����
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // �v���C���[���}�E�X�J�[�\���̕���������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle + 90;
        transform.localEulerAngles = angles;

        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[���X�V����
        //_shotTimer += Time.deltaTime;

        //_shotTimer = 0;// �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g

        // �e�𔭎˂���
        if (_bulletCount > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var player = GameObject.Find("Player");
                _player = player.GetComponent<PlayerController>();
                Fire(angle, _bulletSpeed, _shotCount);
                _bulletCount--;
                if (_player._top == true)//Top
                {
                    _topGun.SetActive(true);
                }
                else if (_player._back == true)//Back
                {
                    _backGun.SetActive(true);
                }
                else if (_player._left == true)//Left
                {
                    _leftGun.SetActive(true);
                }
                else if (_player._right == true)//Right
                {
                    _rightGun.SetActive(true);
                }
            }
        }
    }
    void Fire(float angleBase, float speed, int count)
    {
        var rot = transform.localRotation; // �v���C���[�̌���
        // �e�� 1 �������˂���ꍇ
        if (1 == count && 0 < _bulletCount)
        {
            // ���˂���e�𐶐�����
            var fire = Instantiate(_bulletPrefab, _muzzle.position, rot);

            // �e�𔭎˂�������Ƒ�����ݒ肷��
            fire.Init(angleBase, speed);
        }
    }
    public void UpdateBullet(int bullet)
    {
        _bulletCount += bullet;
    }
}
