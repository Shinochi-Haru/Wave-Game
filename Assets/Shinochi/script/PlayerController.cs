using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    private Vector2 _dir;
    [SerializeField] Transform _enemy;
    [SerializeField] Transform _enemyX;
    [SerializeField] Transform _enemyY;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] BulletController _bulletPrefab = null;
    [SerializeField] float _shotTimer;
    [SerializeField] float _bulletSpeed = 10f;
    private float _shotAngleRange;
    [SerializeField] int _shotCount; // 弾の発射数
    [SerializeField] float _shotInterval; // 弾の発射間隔（秒）
    [SerializeField]private float _speed;
    [SerializeField] int _bulletCount = 0;
    [SerializeField]private int _hp;//体力
    [SerializeField] float _knockBackPower;   // ノックバックさせる力
    SceneCanger sceneCanger;
    //[SerializeField] Transform enemy;
    [SerializeField] GameObject[] heartArray = new GameObject[3];
    Vector3 hitPos;
    Vector2 dir;
    [SerializeField]private bool on_damage;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float DefaultSpeed { get; private set; }
    public float SetSpeed { set { _speed = value; } }

    public SpriteRenderer sp;

    // ダメージ判定フラグ
    private bool isDamage { get; set; }


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
        dir = new Vector2(h, v).normalized;  
        _rb.velocity = dir * _speed;        

        // Player死亡時
        if (Hp < 1)
        {
            Debug.Log("GameOver");
            sceneCanger.LoadScene("Result");
        }

        if (_hp == 3)
        {
            heartArray[2].gameObject.SetActive(true);
            heartArray[1].gameObject.SetActive(true);
            heartArray[0].gameObject.SetActive(true);
        }

        if (_hp == 2)
        {
            heartArray[2].gameObject.SetActive(false);
            heartArray[1].gameObject.SetActive(true);
            heartArray[0].gameObject.SetActive(true);
        }
        if (_hp == 1)
        {
            heartArray[2].gameObject.SetActive(false);
            heartArray[1].gameObject.SetActive(false);
            heartArray[0].gameObject.SetActive(true);
        }

        // ダメージを受けている場合、点滅させる
        if (isDamage)
        {

            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);

        }

    }

    public void UpdateBullet(int bullet)
    {
        _bulletCount += bullet;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 distination = (transform.position - _enemy.transform.position).normalized;
            _rb.AddForce(distination * _knockBackPower, ForceMode2D.Force);
        }
        if (collision.gameObject.tag == "EnemyX")
        {
            Vector3 distination = (transform.position - _enemyX.transform.position).normalized;
            _rb.AddForce(distination * _knockBackPower, ForceMode2D.Force);
        }
        if (collision.gameObject.tag == "EnemyY")
        {
            Vector3 distination = (transform.position - _enemyY.transform.position).normalized;
            _rb.AddForce(distination * _knockBackPower, ForceMode2D.Force);
        }
        StartCoroutine(OnDamage());
    }

    public void Damage(int dam)
    {
        Hp -= dam;
        
        //Vector3 distination = (transform.position - _enemy.transform.position).normalized;
        //_rb.AddForce(distination * _knockBackPower, ForceMode2D.Force);
    }
    public IEnumerator OnDamage()
    {

        yield return new WaitForSeconds(3.0f);

        // 通常状態に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);

    }
}
