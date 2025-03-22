using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOnFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    private void Start()
    {
        fire.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            fire.SetActive(true);
        }
    }
}
