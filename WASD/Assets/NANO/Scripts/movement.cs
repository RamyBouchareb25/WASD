using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class movement : MonoBehaviour

{
    private Transform groudCheck;
    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveMent;
    [SerializeField]
    private float radius;

    [SerializeField] private LayerMask GroundLqyer;
    [SerializeField]
    private float speed = 0f,minVelocity , maxVelocity;
    private bool flip = false;
    
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //groudCheck = GameObject.FindGameObjectWithTag("GroundCheck").GetComponent<Transform>();
    }

 

    public void OnMove(InputAction.CallbackContext callback)
    {
        moveMent = callback.ReadValue<Vector2>();
        if (moveMent.x != 0)
        {
            animator.SetBool("IsWalking", true);
            audioManager.PlaySFX(audioManager.Grass);
        }
        else if(moveMent.x == 0)
        {
            animator.SetBool("IsWalking", false);
        }
       
        if (moveMent.x < 0f)
        {
            flip = true;
            
        }
        else if (moveMent.x > 0f)
        {
            flip = false;
            
        }

    }

    private void CheckGroumd()
    {
         //isGround = Physics2D.OverlapCircleAll(this.tramsform.position, radius, GroundLqyer);
    }

    private void Update()
    {

    }


    private void FixedUpdate()
    {
        rb.AddForce(speed * new Vector2(moveMent.x , 0f) * Time.fixedDeltaTime, ForceMode2D.Force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, minVelocity, maxVelocity), rb.velocity.y);
        FlipPlayer();
    }

    private void Move()
    {

    }

    private void FlipPlayer()
    {
        sprite.flipX = flip;
    }


}
