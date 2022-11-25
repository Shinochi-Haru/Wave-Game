using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] BulletController _bulletPrefab = null;
    [SerializeField] float _bulletSpeed = 10f;
    [SerializeField] int _shotCount; // 弾の発射数
    [SerializeField] int _bulletCount = 0;
    [SerializeField]AudioClip _audio;
    [SerializeField] AudioClip _audio2;
    AudioSource a;
    public int bulletCount { get; private set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのスクリーン座標を計算する
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // プレイヤーから見たマウスカーソルの方向を計算する
        var direction = Input.mousePosition - screenPos;

        // マウスカーソルが存在する方向の角度を取得する
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // プレイヤーがマウスカーソルの方向を見るようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // 弾の発射タイミングを管理するタイマーを更新する
        //_shotTimer += Time.deltaTime;

        //_shotTimer = 0;// 弾の発射タイミングを管理するタイマーをリセット

        // 弾を発射する
        if (_bulletCount > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire(angle, _bulletSpeed, _shotCount);
                _bulletCount--;
                a.PlayOneShot(_audio);
            }
        }
        else if(_bulletCount == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            a.PlayOneShot(_audio2);
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
