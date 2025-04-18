using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaCan : MonoBehaviour
{
    [SerializeField] private GameObject tunaCanOutline;
    [SerializeField] private GameObject tunaCan;
    [SerializeField] private GameObject catJump;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject canCollider;
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private GameObject treeCollider;
    [SerializeField] private OldLadyDialogue dialogue;

    private bool isClose;
    public bool canPlace;

    [SerializeField] private FameManager fameManager;

    // Start is called before the first frame update
    void Start()
    {
        //tunaCanOutline.SetActive(false);
        tunaCan.SetActive(false);
        catJump.SetActive(false);
        cat.SetActive(false);
        ePrompt.SetActive(false);
        isClose = false;
        canPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlaceCan();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ePrompt.SetActive(true);
            isClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ePrompt.SetActive(false);
            isClose = false;
        }
    }

    private void PlaceCan()
    {
        if (Input.GetKeyDown(KeyCode.E) && isClose && canPlace)
        {
            StartCoroutine(CatJump());
        }
    }

    private IEnumerator CatJump()
    {
        tunaCan.SetActive(true);
        yield return new WaitForSeconds(1);
        catJump.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        catJump.SetActive(false);
        cat.SetActive(true);
        canCollider.SetActive(false);
        treeCollider.SetActive(false);
        dialogue.canPlaced = true;
        fameManager.fame++;
        fameManager.oldLady = true;

    }
}
