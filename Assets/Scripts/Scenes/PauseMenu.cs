using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject pauseMenu;
    public bool isPaused;
    public bool ableToPause;

    // Start is called before the first frame update
    void Start()
    {
        ableToPause = true;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ableToPause == true)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

            
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        pauseMenu.SetActive(true);
        ClickSound();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseMenu.SetActive(false);
        ClickSound();
    }

    public void SetScene(string scene)
    {
        ClickSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene(scene);
        
    }

    void ClickSound()
    {
        buttonSound.Play();
    }
}

