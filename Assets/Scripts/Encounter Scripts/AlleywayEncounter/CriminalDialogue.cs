using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CriminalDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index = 0;
    public float dialogueSpeed;
    private int count = 0;
    [SerializeField] private GameObject dialogueBox;

    [Header("Encounter")]
    [SerializeField] private GameObject criminal1;
    [SerializeField] private GameObject criminal2;
    [SerializeField] private GameObject mug1;
    [SerializeField] private GameObject mug2;
    public bool isSolved;

    [SerializeField] public FameManager fameManager;

    private bool canPressE = true;
    private bool closeToPlayer;

    

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (canPressE) && (closeToPlayer))
        {
            dialogueBox.SetActive(true);
            NextSentence();
        }

        if (count == 4)
        {
            mug1.SetActive(false);
            mug2.SetActive(true);
        }

        if (isSolved)
        {
            criminal1.SetActive(false);
            criminal2.SetActive(true);
            fameManager.fame++;
            fameManager.alleyway = true;
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
