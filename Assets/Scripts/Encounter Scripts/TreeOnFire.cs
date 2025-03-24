using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOnFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject burntCatJump;
    [SerializeField] private GameObject burntCat;

    private void Start()
    {
        burntCat.SetActive(false);
        burntCatJump.SetActive(false);
        fire.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            fire.SetActive(true);
            StartCoroutine(CatJump());
        }
    }

    private IEnumerator CatJump()
    {
        yield return new WaitForSeconds(1);
        burntCatJump.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        burntCatJump.SetActive(false);
        burntCat.SetActive(true);
    }
}
