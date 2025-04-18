using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOnFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject burntCatJump;
    [SerializeField] private GameObject burntCat;
    [SerializeField] private GameObject treeCollider;
    [SerializeField] private GameObject canObject;
    [SerializeField] public OldLadyDialogue dialogue;
    [SerializeField] private FameManager fameManager;

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
        canObject.SetActive(false);
        yield return new WaitForSeconds(1);
        burntCatJump.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        burntCatJump.SetActive(false);
        burntCat.SetActive(true);
        treeCollider.SetActive(false);       
        dialogue.treeOnFire = true;
        fameManager.fame--;
        fameManager.oldLady = true;
    }
}
