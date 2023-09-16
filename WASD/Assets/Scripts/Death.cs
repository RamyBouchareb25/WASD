using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private MinionOrganiser minionOrganiser;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
        }
        else if (collision.gameObject.CompareTag("Minion"))
        {
            minionOrganiser.DeleteMinion(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
        }
        else if (collision.gameObject.CompareTag("Minion"))
        {
            minionOrganiser.DeleteMinion(1);
        }
    }
}
