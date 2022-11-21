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
    [SerializeField] int _shotCount; // 弾の発射数
    [SerializeField] float _shotInterval; // 弾の発射間隔（秒）
    [SerializeField]private float _speed;
    [SerializeField] int _bulletCount = 0;
    [SerializeField]private int _hp;
    SceneCanger sceneCanger;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float DefaultSpeed { get; private set; }
    public float SetSpeed { set { _speed = value; } }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        HpMax = _hp;
        DefaultSpeed = _speed;
        sceneCanger = GetComponent<SceneCanger>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   
        float v = Input.GetAxisRaw("Vertical");     
        Vector2 dir = new Vector2(h, v).normalized;  
        _rb.velocity = dir * _movePower;        

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
        _shotTimer += Time.deltaTime;

        _shotTimer = 0;// 弾の発射タイミングを管理するタイマーをリセットする

        // 弾を発射する
        if (Input.GetButtonDown("Fire1"))
        {
            Fire(angle, _bulletSpeed, _shotCount);
            _bulletCount--;
        }

        // Player死亡時
        if (Hp < 1)
        {
            Debug.Log("GameOver");
            sceneCanger.LoadScene();
        }
    }

    // 弾を発射する関数
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

    public void Damage(int dam)
    {
        Hp -= dam;
    }
}
