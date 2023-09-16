using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Chief : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Transform target;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

    }

    private void GetToPosition()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - (target.position.x)) > 0.1f)
        {
            animator.SetBool("IsPointing", true);
        }
    }
}
