using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChange : MonoBehaviour
{
    [SerializeField] private GameObject ePrompt;
    [SerializeField] private Transform player;
    [SerializeField] private Transform targetLocation;
    [SerializeField] private GameObject camBounds1;
    [SerializeField] private GameObject camBounds2;
    [SerializeField] private GameObject cmCam1;
    [SerializeField] private GameObject cmCam2;

    bool canChange;

    // Start is called before the first frame update
    void Start()
    {
        camBounds1.SetActive(true);
        camBounds2.SetActive(true);
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
            StartCoroutine(BoundDeactivator());
            player.position = new Vector2 (targetLocation.position.x, targetLocation.position.y);
        }
    }

    private IEnumerator BoundDeactivator()
    {
        camBounds1.SetActive (false);
        cmCam1.SetActive (false);
        yield return new WaitForSeconds(0.01f);
        camBounds2.SetActive (true);
        cmCam2.SetActive (true);
    }
}
