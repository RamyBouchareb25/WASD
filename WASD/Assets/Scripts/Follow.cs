using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform chiefPosition;
    private Rigidbody2D rb;

    [SerializeField]
    private float minPosition = 10f, speed,minVelocity,maxVelocity; 
    [SerializeField]
    private float min, max, minSpeed, maxSpeed;
    private float randomOffset;
    private SpriteRenderer sprite;
    private Animator animator;
    private bool isFollowing;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        chiefPosition = GameObject.FindGameObjectWithTag("Player").transform;
        randomOffset = Random.Range(min, max);
        speed = Random.Range(minSpeed, maxSpeed);

    }
    private void FixedUpdate()
    {
        FollowCHief();
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, minVelocity, maxVelocity), rb.velocity.y);
    }

    private void FollowCHief()
    {
        Vector2 direction = (chiefPosition.position - transform.position).normalized;
        FlipMinion();

        
        if (Mathf.Abs(transform.position.x - (chiefPosition.position.x + randomOffset)) > 0.1f)
        {
            isFollowing = true;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            isFollowing = false;
            animator.SetBool("IsWalking", false);
        }

        
        if (isFollowing)
        {
            rb.AddForce(speed * direction * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }


    private void FlipMinion()
    {
        Vector2 direction = chiefPosition.position - this.transform.position;
        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else if(direction.x > 0f)
        {
            sprite.flipX = false;
        }
    }





}
