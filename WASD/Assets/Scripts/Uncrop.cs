using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncrop : MonoBehaviour
{
    
    [SerializeField]
    private LayerMask Crop;
    [SerializeField]
    private float radius = 5f;

    private void Start()
    {

    }
    private void Detection()
    {
        Collider2D[] cropColliders = Physics2D.OverlapCircleAll(this.transform.position, radius, Crop);

        foreach (Collider2D collider in cropColliders)
        {
           Debug.Log(collider.name);
            
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
