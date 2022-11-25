using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] AudioClip _speedUp;
    [SerializeField] AudioClip _recover;
    [SerializeField] GameObject player;

    Animator _anim;

    public bool isTop = false;
    public bool isBack = false;
    public bool isLeft = false;
    public bool isRight = false;
    [SerializeField] GameObject _topGun;
    [SerializeField] GameObject _backGun;
    [SerializeField] GameObject _leftGun;
    [SerializeField] GameObject _rightGun;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float DefaultSpeed { get; private set; }
    public float SetSpeed { set { _speed = value; } }

    public bool IsMove { get; set; } = true;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        HpMax = _hp;
        DefaultSpeed = _speed;
        sceneCanger = GetComponent<SceneCanger>();
        renderer = GetComponent<Renderer>();
        _audio = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            _anim.SetFloat("SpeedX", h);
            _anim.SetFloat("SpeedY", v);
            FlipX(h);
            FlipY(v);
            _dir = new Vector2(h, v).normalized;
            _rb.velocity = _dir * _speed;
        }

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
            Instantiate(player, this.transform.position, Quaternion.identity);
            Debug.Log("GameOver");
            this.gameObject.SetActive(false);
        }
    }

    public void FlipX(float hol)
    {
        if (hol < 0)//left
        {
            isTop = false;
            isBack = false;
            isLeft = true;
            isRight = false;
            _topGun.SetActive(false);
            _backGun.SetActive(false);
            _leftGun.SetActive(true);
            _rightGun.SetActive(false);
            _anim.SetBool("isTop", false);
            _anim.SetBool("isBack", false);
            _anim.SetBool("isLeft", true);
            _anim.SetBool("isRight", false);
        }
        else if (hol > 0)//right
        {
            isTop = false;
            isBack = false;
            isLeft = false;
            isRight = true;
            _topGun.SetActive(false);
            _backGun.SetActive(false);
            _leftGun.SetActive(false);
            _rightGun.SetActive(true);
            _anim.SetBool("isTop", false);
            _anim.SetBool("isBack", false);
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", true);
        }
    }

    public void FlipY(float ver)
    {
        if (ver < 0)//top
        {
            isTop = false;
            isBack = false;
            isLeft = false;
            isRight = true;
            _topGun.SetActive(true);
            _backGun.SetActive(false);
            _leftGun.SetActive(false);
            _rightGun.SetActive(false);
            _anim.SetBool("isTop", true);
            _anim.SetBool("isBack", false);
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", false);
        }
        else if (ver > 0)//back
        {
            isTop = false;
            isBack = true;
            isLeft = false;
            isRight = false;
            _topGun.SetActive(false);
            _backGun.SetActive(true);
            _leftGun.SetActive(false);
            _rightGun.SetActive(false);
            _anim.SetBool("isTop", false);
            _anim.SetBool("isBack", true);
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", false);
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

        if (col.gameObject.tag == "SpeedDown")
        {
            _audio.PlayOneShot(_speedDown);
        }

        if (col.gameObject.tag == "Recover")
        {
            _audio.PlayOneShot(_recover);
        }

        if (col.gameObject.tag == "SpeedUp")
        {
            _audio.PlayOneShot(_speedUp);
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
        _anim.SetTrigger("Damage");
        _audio.PlayOneShot(_audioDamage);
    }
}
