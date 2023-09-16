using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform chiefPosition;
    private Rigidbody2D rb;

    [SerializeField]
    private float minPosition = 10f, speed; 
    [SerializeField]
    private float min, max, minSpeed, maxSpeed;
    private float randomOffset;
    private SpriteRenderer sprite;
    private Animator animator;
    private Vector2 targetPosition;
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
        
    }

    private void FollowCHief()
    {
        

        FlipMinion();
        targetPosition= new Vector2(chiefPosition.position.x + randomOffset, this.transform.position.y);

        this.transform.position= Vector2.MoveTowards(this.transform.position,targetPosition, speed * Time.deltaTime);
        

        if (Mathf.Abs(transform.position.x - (targetPosition.x)) > 0.1f)
        {
            isFollowing = true;
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            isFollowing = false;
            animator.SetBool("IsWalking", false);
        }
    }


    private void FlipMinion()
    {
        Vector2 direction = targetPosition - new Vector2(this.transform.position.x ,this.transform.position.y);
        if (direction.x < 0f)
        {
            sprite.flipX = true;
            randomOffset = -randomOffset;
        }
        else if(direction.x > 0f)
        {
            sprite.flipX = false;
            randomOffset = -randomOffset;
        }
    }





}
