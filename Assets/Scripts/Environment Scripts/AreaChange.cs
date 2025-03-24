using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChange : MonoBehaviour
{
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private Transform player;
    [SerializeField] private Transform targetLocation;

    bool canChange;

    // Start is called before the first frame update
    void Start()
    {
        ePrompt.SetActive(false);
        canChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeArea();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ePrompt.SetActive(true);
            canChange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ePrompt.SetActive(false);
            canChange = false;
        }
    }

    private void ChangeArea()
    {
        if (Input.GetKeyDown(KeyCode.E) && canChange) 
        { 
            player.position = new Vector2 (targetLocation.position.x, targetLocation.position.y);
        }
    }
}
