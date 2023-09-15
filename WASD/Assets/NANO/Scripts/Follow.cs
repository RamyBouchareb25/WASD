using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform chiefPosition;

    [SerializeField]
    private float minPosition = 10f, speed;

    private void Start()
    {
        chiefPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        //FollowCHief();
    }
    private void FollowCHief()
    {
        Vector2 direction = chiefPosition.position - this.transform.position;

        float distance = direction.magnitude;

        if (distance > minPosition)
        {
            Vector2 movement = Vector2.MoveTowards(this.transform.position, chiefPosition.position, speed * Time.deltaTime);

            this.transform.position = movement;
        }

    }
}
