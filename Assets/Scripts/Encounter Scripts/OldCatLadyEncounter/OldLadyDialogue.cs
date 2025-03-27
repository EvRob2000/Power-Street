using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldLadyDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index = 0;
    public float dialogueSpeed;
    private int count = 0;

    private bool canPressE = true;
    private bool closeToPlayer;

    [SerializeField] private GameObject dialogueBox;

    public bool treeOnFire;
    public bool canPlaced;

    [SerializeField] private GameObject oldLady;
    [SerializeField] private GameObject oldLadyGood;
    [SerializeField] private GameObject oldLadyBad;

    private void Start()
    {
        dialogueBox.SetActive(false);
        treeOnFire = false;
        canPlaced = false;
        oldLadyGood.SetActive(false);
        oldLadyBad.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (canPressE) && (closeToPlayer))
        {
            dialogueBox.SetActive(true);
            NextSentence();
        }

        Debug.Log(count);

        if (treeOnFire)
        {
            oldLady.SetActive(false);
            oldLadyBad.SetActive(true);
        }

        if (canPlaced)
        {
            oldLady.SetActive(false);
            oldLadyGood.SetActive(true);
        }
    }

    void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closeToPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closeToPlayer = false;
            dialogueBox.SetActive(false);

            index = 0;
        }
    }

    IEnumerator WriteSentence()
    {
        canPressE = false;

        foreach (char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }

        index++;
        count++;
        canPressE = true;

    }
}
