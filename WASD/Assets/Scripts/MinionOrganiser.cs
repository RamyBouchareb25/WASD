using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionOrganiser : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> minions = new List<GameObject>();
    private Transform[] childs;

    private void Awake()
    {

    }
    private void Start()
    {
        childs = gameObject.GetComponentsInChildren<Transform>();
        if(childs != null)
        {
            foreach(Transform t in childs)
            {
                minions.Add(t.gameObject);
                Debug.Log(t);
            }
        }
    }
    private void AddMinion()
    {

    }
    private void DeleteMinion()
    {

    }

}
