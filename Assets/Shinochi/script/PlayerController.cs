using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    private Vector2 _dir;
    [SerializeField] Transform _muzzle = null;
    [SerializeField]private float _speed;
    [SerializeField] int _bulletCount = 0;
    [SerializeField]private int _hp;//体力
    SceneCanger sceneCanger;
    [SerializeField] GameObject[] heartArray = new GameObject[3];
    private new Renderer renderer;
    [SerializeField] float flashConut;
    [SerializeField] int flashLoop;
    AudioSource _audio;
    [SerializeField] AudioClip _audioReroad;
    [SerializeField] AudioClip _audioDamage;
    [SerializeField] AudioClip _speedDown;

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
        renderer = GetComponent<Renderer>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   
        float v = Input.GetAxisRaw("Vertical");     
        _dir = new Vector2(h, v).normalized;  
        _rb.velocity = _dir * _speed;        

        // Player死亡時
        if (_hp == 3)
        {
            heartArray[2].gameObject.SetActive(true);
            heartArray[1].gameObject.SetActive(true);
            heartArray[0].gameObject.SetActive(true);
        }

        else if (_hp == 2)
        {
            heartArray[2].gameObject.SetActive(false);
            heartArray[1].gameObject.SetActive(true);
            heartArray[0].gameObject.SetActive(true);
        }
        else if (_hp == 1)
        {
            heartArray[2].gameObject.SetActive(false);
            heartArray[1].gameObject.SetActive(false);
            heartArray[0].gameObject.SetActive(true);
        }
        else if (Hp < 1)
        {
            Debug.Log("GameOver");
            sceneCanger.LoadScene("Result");
        }
    }

    public void UpdateBullet(int bullet)
    {
        _bulletCount += bullet;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Enemyとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyX" || col.gameObject.tag == "EnemyY")
        {
            StartCoroutine("Damage");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            StartCoroutine("Damage");
        }

        if (col.gameObject.tag == "BulletPlus")
        {
            _audio.PlayOneShot(_audioReroad);
        }
    }

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
    }


    public void Damage(int dam)
    {
        Hp -= dam;
        _audio.PlayOneShot(_audioDamage);
    }
}
