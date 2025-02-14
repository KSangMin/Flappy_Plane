using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    public float jumpForce = 6f;
    public float speed = 3f;
    private bool _isDead = false;
    private float _deathCool = 0f;

    bool isFlap = false;

    public bool godMode = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        if (_animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rb == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (_isDead)
        {
            if(_deathCool > 0f)
            {
                _deathCool += Time.deltaTime;
            }
            else
            {
                //게임 재시작
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(0))
            {
                isFlap = true;

            }
        }
    }
     
    private void FixedUpdate()
    {
        if (_isDead) return;

        Vector3 velocity = _rb.velocity;
        velocity.x = speed;

        if (isFlap)
        {
            velocity.y += jumpForce;
            isFlap = false;
        }

        _rb.velocity = velocity;

        float angle = Mathf.Clamp(_rb.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (_isDead) return;

        _isDead = true;
        _deathCool = 1f;

        _animator.SetBool("isDead", true);
    }
}
