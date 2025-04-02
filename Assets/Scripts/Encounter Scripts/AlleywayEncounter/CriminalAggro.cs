using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalAggro : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject criminal;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);
        criminal.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            enemy.SetActive(true);
            criminal.SetActive(false);
        }
    }

}
