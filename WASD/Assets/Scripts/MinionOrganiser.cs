using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MinionOrganiser : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> minions = new List<GameObject>();
    private Transform[] childs;
    [SerializeField]
    private GameObject childCrops;
    [SerializeField]
    private int min, max;
    [SerializeField]
    private TextMeshProUGUI minionCounter;
    private bool buildable = false;

    private void Awake()
    {

    }
    private void Start()
    {
        childs = GetComponentsInChildren<Transform>();
        if (childs != null)
        {
            foreach (Transform t in childs)
            {   if (t == this.transform) continue;
                minions.Add(t.gameObject);

                Debug.Log(minions.Count);

            }
            UpdateMinionCounter();
        }
        minionCounter = GameObject.FindGameObjectWithTag("TxTCounter").GetComponent<TextMeshProUGUI>();
        UpdateMinionCounter();
    }

    public void AddMinion()
    {
        int numberOfCrops = Random.Range(min, max);

        for (int i = 0; i < numberOfCrops; i++)
        {
            GameObject newMinion = Instantiate(childCrops, this.transform.position, Quaternion.identity);
            newMinion.transform.parent = this.transform;
            minions.Add(newMinion);
            Debug.Log(minions.Count);
            UpdateMinionCounter();
        }
    }
    public bool DeleteMinion(int count)
    {
        Debug.Log(count + " " + minions.Count);
        if (count < minions.Count)
        {
            buildable = true;
           
            for (int i = 0; i < count; i++)
            {
                Destroy(minions[i]);
                minions.RemoveAt(i);
            }
            UpdateMinionCounter();
            return true;
        }
        else
        {
            return false;
                    }

    }
    private void UpdateMinionCounter()
    {
        Debug.Log(minionCounter.text);
        minionCounter.text = minions.Count.ToString();
    }
    public bool Buildable()
    {
        return buildable;
    }
   
}
