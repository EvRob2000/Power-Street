using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    [SerializeField] private GameObject ePrompt;

    private void Start()
    {
        outline.SetActive(false);
        ePrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Interact available");
            //outline.SetActive(true);
            ePrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //outline.SetActive(false);
            ePrompt.SetActive(false);
        }
    }
}
