using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    bool isGamePaused;
    [SerializeField] private GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isGamePaused)
        {
            pauseScreen.SetActive(true);
            isGamePaused = true;
            Time.timeScale = 0; 
        }
        else if (Input.GetKeyDown(KeyCode.P) && isGamePaused)
        {
            pauseScreen.SetActive(false);
            isGamePaused = false;
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
