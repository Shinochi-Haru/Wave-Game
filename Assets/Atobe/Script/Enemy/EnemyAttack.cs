using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍U���𐧌䂷��R���|�[�l���g
/// </summary>

public class EnemyAttack : MonoBehaviour
{
    [Header("�e��Prefab")]
    [SerializeField] GameObject _enemyBulletPrefab = null;
    //[Header("���˃C���^�[�o��")]
    //[SerializeField] float _fireInterval = 1f;
    [Header("�}�Y��")]
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
