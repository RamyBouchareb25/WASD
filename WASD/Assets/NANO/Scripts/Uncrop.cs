using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Uncrop : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask Crop;
    [SerializeField]
    private float radius = 5f;
    private Animator animator;
    private bool isHitting = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {

    }
    private void Detection()
    {
        Collider2D[] cropColliders = Physics2D.OverlapCircleAll(this.transform.position, radius, Crop);

        foreach (Collider2D collider in cropColliders)
        {   if(collider != null)
            {
                Debug.Log(collider.name);
                isHitting = true;
            }
            else
            {
                isHitting = false;
            }
           
           
        }


    }

    private void OnInteract()
    {
        if (isHitting)
        {
            animator.SetTrigger("IsInteracting");
        }
       
    }

    private void Update()
    {
        Detection();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
