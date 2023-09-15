using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Uncrop : MonoBehaviour
{
    [SerializeField]
    private GameObject curentCrop;
    [SerializeField]
    private LayerMask Crop;
    [SerializeField]
    private float radius = 5f;
    private Animator animator;
    private bool isHitting = true;
    private bool IsInteracting = false;
    private float savePosition;
    private Rigidbody2D rb;
    private movement moving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moving = GetComponent<movement>();  
    }

    private void Start()
    {
        isHitting = false;
        IsInteracting = false;
         savePosition = this.transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crop"))
        {
            print("Hit");
            isHitting = true;
            curentCrop = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crop"))
        {
            isHitting = false;
            curentCrop = null;
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        print("on interact");
        if (isHitting)
        {
            Debug.Log(isHitting);

            IsInteracting = true;
            if (IsInteracting && context.performed)
            {
                
                this.transform.position = new Vector2(this.transform.position.x, -1.71f);
                
                if (curentCrop != null)
                Destroy(curentCrop);
                animator.SetBool("IsInteracting", true);
                StartCoroutine(wait());
                StartCoroutine(ActivateMovement());
            }

        }

    }

    private void Update()
    {
        if (IsInteracting)
        {
            moving.enabled = false;
        }
        else
        {
            moving.enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.50f);
        Debug.Log("I am working");
        animator.SetBool("IsInteracting", false);
        IsInteracting = false;
    }
    private IEnumerator ActivateMovement()
    {
        Debug.Log("Please work");
        yield return new WaitForSeconds(4f);
        IsInteracting = false;
    }



}
