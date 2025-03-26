using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCan : MonoBehaviour
{
    [SerializeField] private GameObject tunaCan;
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private TunaCan tCan;

    private bool isClose;

    // Start is called before the first frame update
    void Start()
    {
        ePrompt.SetActive(false);
        isClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        TakeCan();
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

    private void TakeCan()
    {
        if (Input.GetKeyDown(KeyCode.E) && isClose)
        {
            tunaCan.SetActive(false);
            tCan.canPlace = true;
        }
    }
}
