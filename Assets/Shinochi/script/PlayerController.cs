using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    private Vector2 _dir;
    [SerializeField]private float _speed;
    [SerializeField]private int _hp;//体力
    SceneCanger sceneCanger;
    [SerializeField] GameObject[] heartArray = new GameObject[3];
    private new Renderer renderer;
    [SerializeField] float flashConut;
    [SerializeField] int flashLoop;

    [SerializeField] GameObject _topGun;
    [SerializeField] GameObject _backGun;
    [SerializeField] GameObject _leftGun;
    [SerializeField] GameObject _rightGun;
    [SerializeField] GameObject _playerDead;

    Animator _anim;

    public int HpMax { get; private set; }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float DefaultSpeed { get; private set; }
    public float SetSpeed { set { _speed = value; } }


    public bool _top = false;
    public bool _back = false;
    public bool _left = false;
    public bool _right = false;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        HpMax = _hp;
        DefaultSpeed = _speed;
        sceneCanger = GetComponent<SceneCanger>();
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        _anim.SetFloat("SpeedX", _rb.velocity.x);
        _anim.SetFloat("SpeedY", _rb.velocity.y);
        float h = Input.GetAxisRaw("Horizontal");   //Horizontal -1 = Left
        float v = Input.GetAxisRaw("Vertical");     //Vertical -1 = Down
        _dir = new Vector2(h, v).normalized;  
        _rb.velocity = _dir * _speed;
        FlipX(h);
        FlipY(v);

        // Player死亡時
        if (Hp < 1)
        {
            Debug.Log("GameOver");
            Instantiate(_playerDead, this.transform.position, _playerDead.transform.rotation);
            Destroy(this.gameObject);
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
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Enemyとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyX" || col.gameObject.tag == "EnemyY")
        {
            StartCoroutine("Damage");
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
    }
    void FlipX(float h)
    {
        // Player が右を向いているとき
        if (h > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // Player が左を向いているとき
        else if (h < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }

        if (h < 0)//Left
        {
            _left = true;
            _right = false;
            _top = false;
            _back = false;
            _anim.SetBool("isLeft",true);
            _anim.SetBool("isRight",false);
            _anim.SetBool("isTop",false);
            _anim.SetBool("isBack",false);
            _topGun.SetActive(false);
            _backGun.SetActive(false);
            _leftGun.SetActive(true);
            _rightGun.SetActive(false);
        }
        else if (h > 0)//Right
        {
            _right = true;
            _left = false;
            _top = false;
            _back = false;
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", true);
            _anim.SetBool("isTop", false);
            _anim.SetBool("isBack", false);
            _topGun.SetActive(false);
            _backGun.SetActive(false);
            _leftGun.SetActive(false);
            _rightGun.SetActive(true);
        }
    }

    void FlipY(float v)
    {
        if (v < 0)//Down
        {
            _top = true;
            _back = false;
            _left = false;
            _right = false;
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", false);
            _anim.SetBool("isTop", true);
            _anim.SetBool("isBack", false);
            _topGun.SetActive(true);
            _backGun.SetActive(false);
            _leftGun.SetActive(false);
            _rightGun.SetActive(false);
        }
        else if (v > 0)//Up
        {
            _back = true;
            _top = false;
            _left = false;
            _right = false;
            _anim.SetBool("isLeft", false);
            _anim.SetBool("isRight", false);
            _anim.SetBool("isTop", false);
            _anim.SetBool("isBack", true);
            _topGun.SetActive(false);
            _backGun.SetActive(true);
            _leftGun.SetActive(false);
            _rightGun.SetActive(false);
        }
    }
}
