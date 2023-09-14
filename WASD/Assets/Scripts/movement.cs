using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveMent;
    [SerializeField]
    private float speed = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext callback)
    {
       moveMent = callback.ReadValue<Vector2>().x;
       
    }


    private void Update()
    {
       
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveMent * speed, rb.velocity.y);
    }


}
