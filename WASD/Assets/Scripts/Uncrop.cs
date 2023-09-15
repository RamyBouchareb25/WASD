using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncrop : MonoBehaviour
{
    RaycastHit2D hit;
    [SerializeField]
    private Vector2 offset;
    private void Start()
    {

    }

    private void Raycast()
    {
        Vector2 direction = new Vector2(this.transform.position.x , this.transform.position.y) + offset;
        Physics2D.Raycast(this.transform.position, direction);
    }
}
