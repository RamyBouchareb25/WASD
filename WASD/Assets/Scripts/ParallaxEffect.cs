using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float postion, length;
    private GameObject camera;
    [SerializeField]
    private float parallaxEffect;
    void Start()
    {
        postion = this.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        camera = GameObject.FindGameObjectWithTag("Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float temp = (camera.transform.position.x * 1 - parallaxEffect);
        float dist = (camera.transform.position.x * parallaxEffect);

            this.transform.position = new Vector3(postion + dist , this.transform.position.y , this.transform.position.z);
    }
}
