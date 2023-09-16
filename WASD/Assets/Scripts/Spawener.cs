using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawener : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject minionPrefab;
    [SerializeField]
    private float time;
    void Start()
    {
        InvokeRepeating(nameof(SPawning), time, time);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SPawning()
    {
        Instantiate(minionPrefab, this.transform.position, Quaternion.identity);
    }
}
