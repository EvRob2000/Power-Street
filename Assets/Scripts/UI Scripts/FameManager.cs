using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FameManager : MonoBehaviour
{
    public float fame;
    [SerializeField] private TextMeshProUGUI fameTxt;
    [SerializeField] private TextMeshProUGUI fameNum;
    // Start is called before the first frame update
    void Start()
    {
        fame = 0;
        fameTxt.GetComponent<TextMeshProUGUI>();
        fameNum.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        FameScore();
    }

    private void FameScore()
    {
        fameNum.text = $"{fame}";

        if(fame == 0)
        {
            fameTxt.text = "Nobody";
        }
        else if(fame > 0)
        {
            fameTxt.text = "Fame";
        }
        else if (fame < 0)
        {
            fameTxt.text = "Infamy";
        }
    }
}
