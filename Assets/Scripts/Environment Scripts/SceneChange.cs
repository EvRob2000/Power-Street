using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private string scene;

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
            SceneManager.LoadScene(scene);
        }
    }
}
