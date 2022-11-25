using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    float _scaleX;
    float _h;
    Animator _animator;
    Rigidbody2D _rb = default;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");

        FlipX(_h);
    }

    void FlipX(float horizontal)
    {
        _scaleX = this.transform.localScale.x;


        // Player ���E�������Ă���Ƃ�
        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // Player �����������Ă���Ƃ�
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    private void LateUpdate()
    {
        // �A�j���[�V�����𐧌䂷��
        if (_animator)
        {
            _animator.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
            _animator.SetFloat("SpeedY", _rb.velocity.y);
        }
    }
}
