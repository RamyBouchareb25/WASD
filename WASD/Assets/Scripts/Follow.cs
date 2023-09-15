using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform chiefPosition;

    [SerializeField]
    private float minPosition = 10f, speed;
    [SerializeField]
    private LayerMask chiefLayer, minionLayer;
    [SerializeField]
    private float min, max,minSpeed, maxSpeed;
    private float randomOffset;


    private void Start()
    {
        chiefPosition = GameObject.FindGameObjectWithTag("Player").transform;
        randomOffset = Random.Range(min, max);
        speed = Random.Range(minSpeed, maxSpeed);

    }
    private void Update()
    {
        
        FollowCHief();
    }
    private void FollowCHief()
    {
        //Vector2 direction = chiefPosition.position - this.transform.position;

        Vector2 newPosition = Vector2.MoveTowards(this.transform.position, new Vector2(chiefPosition.position.x + randomOffset, chiefPosition.position.y), speed * Time.deltaTime);

        this.transform.position = new Vector2(newPosition.x , this.transform.position.y);
    }



}
