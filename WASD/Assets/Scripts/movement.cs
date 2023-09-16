using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 moveMent;
    [SerializeField]
    private float speed = 0f,minVelocity , maxVelocity;
    private bool flip = false;
    [SerializeField]
    private Sprite playerSprite;
    private AudioManager audioManager;
    [SerializeField] 
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isGrounded = false;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void isgroundChecking() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
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


    private void Update()
    {
        isgroundChecking();

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
    public void jump(InputAction.CallbackContext ctx)
    {
        if(isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    private void FlipPlayer()
    {
        sprite.flipX = flip;
    }


}
