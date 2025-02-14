using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;

    public float jumpForce = 6f;
    public float speed = 3f;
    public bool isDead = false;
    float deathCool = 0f;

    bool isFlap = false;

    public bool godMode = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (rb == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)
        {
            if(deathCool > 0f)
            {
                deathCool += Time.deltaTime;
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
        if (isDead) return;

        Vector3 velocity = rb.velocity;
        velocity.x = speed;

        if (isFlap)
        {
            velocity.y += jumpForce;
            isFlap = false;
        }

        rb.velocity = velocity;

        float angle = Mathf.Clamp(rb.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCool = 1f;

        animator.SetBool("isDead", true);
    }
}
