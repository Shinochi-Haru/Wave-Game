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
    [SerializeField] int _shotCount; // 弾の発射数
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

        // プレイヤーのスクリーン座標を計算する
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // プレイヤーから見たマウスカーソルの方向を計算する
        var direction = Input.mousePosition - screenPos;

        // マウスカーソルが存在する方向の角度を取得する
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // プレイヤーがマウスカーソルの方向を見るようにする
        var angles = transform.localEulerAngles;
        angles.z = angle + 90;
        transform.localEulerAngles = angles;

        // 弾の発射タイミングを管理するタイマーを更新する
        //_shotTimer += Time.deltaTime;

        //_shotTimer = 0;// 弾の発射タイミングを管理するタイマーをリセット

        // 弾を発射する
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
        var rot = transform.localRotation; // プレイヤーの向き
        // 弾を 1 つだけ発射する場合
        if (1 == count && 0 < _bulletCount)
        {
            // 発射する弾を生成する
            var fire = Instantiate(_bulletPrefab, _muzzle.position, rot);

            // 弾を発射する方向と速さを設定する
            fire.Init(angleBase, speed);
        }
    }
    public void UpdateBullet(int bullet)
    {
        _bulletCount += bullet;
    }
}
