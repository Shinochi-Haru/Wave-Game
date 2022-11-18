using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Tooltip("")]
    [SerializeField] Vector2 _dir;
    [SerializeField] Transform _pointer = null;
    [SerializeField] float _bulletSpeed = 10f;
    Rigidbody2D _rb;
    [SerializeField] float _lifetime = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GameObject _point = GameObject.FindGameObjectWithTag("point");
        Vector2 v = _point.transform.position - this.transform.position;
        v = v.normalized * _bulletSpeed;
        _rb.velocity = v;
    }
    private void Update()
    {
        Destroy(gameObject,_lifetime);     
    }
}
