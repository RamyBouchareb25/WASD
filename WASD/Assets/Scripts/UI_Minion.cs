using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Minion : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;
    void Start()
    {
       _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetToPosition();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AnimationSetter"))
        {
            _animator.SetBool("IsJumping", true);
        }
    }

    private void GetToPosition()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }
}
