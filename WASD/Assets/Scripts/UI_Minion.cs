using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Minion : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    
    private Transform target;
    [SerializeField]
    private float speed;
    void Start()
    {
        _animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("target").GetComponent<Transform>();
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
            
        }
    }

    private void GetToPosition()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }
}
