using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCollider : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private FameManager fameManager;
    [SerializeField] private TextMeshProUGUI fameNum;

    private void Start()
    {
        endScreen.SetActive(false);
        fameNum.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            endScreen.SetActive(true);
            fameNum.text = $"{fameManager.fame}";
        }
    }
}
