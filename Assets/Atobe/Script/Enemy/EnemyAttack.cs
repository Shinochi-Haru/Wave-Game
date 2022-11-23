using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の攻撃を制御するコンポーネント
/// </summary>

public class EnemyAttack : MonoBehaviour
{
    [Header("弾のPrefab")]
    [SerializeField] GameObject _enemyBulletPrefab = null;
    //[Header("発射インターバル")]
    //[SerializeField] float _fireInterval = 1f;
    [Header("マズル")]
    [SerializeField] Transform _muzzle = null;
    //float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_enemyBulletPrefab)
        //{
        //    _timer += Time.deltaTime;
        //    if (_timer > _fireInterval)
        //    {
        //        GameObject chargeBullet = Instantiate(_enemyBulletPrefab);
        //        chargeBullet.transform.position = _muzzle.position;
        //        _timer = 0f;
        //    }
        //}
    }

    public void Fira()
    {
        GameObject chargeBullet = Instantiate(_enemyBulletPrefab);
        chargeBullet.transform.position = _muzzle.position;
    }
}
