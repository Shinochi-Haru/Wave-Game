using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    private Vector2 _dir;
    [SerializeField]private Vector2 _movePower;
    [SerializeField] Transform _muzzle = null;
    [SerializeField] GameObject _bulletPrefab = null;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = new Vector2(h, v);

        if (_rb.velocity != Vector2.zero)
        {
            this.transform.up = _rb.velocity;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        if (_bulletPrefab && _muzzle) // 弾をMuzzleから撃つ
        {
            GameObject go = Instantiate(_bulletPrefab, _muzzle.position, _bulletPrefab.transform.rotation);//弾をインスタンス化
            go.transform.SetParent(this.transform);
        }
    }
    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower, ForceMode2D.Force);
    }
}
