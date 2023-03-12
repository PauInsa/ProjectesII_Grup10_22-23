using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controls;
    bool showingControls;
    bool isPaused;
    public bool ableToPause;

    // Start is called before the first frame update
    void Start()
    {
        ableToPause = true;
        isPaused = false;
        showingControls = false;
        pauseMenu.SetActive(false);
        controls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && ableToPause == true)
        {
            if (isPaused)
            {
                ResumeGame();
                TogglePauseActive();
            }
            else
            {
                PauseGame();
                TogglePauseActive();
            }
        }

    }

    public void TogglePauseActive()
    {
        pauseMenu.SetActive(!pauseMenu.active);
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void SetScene(string scene)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene(scene);
    }

    public void ShowControls()
    {
        if (showingControls)
        {
            controls.SetActive(false);
            showingControls = false;
        }
        else
        {
            controls.SetActive(true);
            showingControls = true;
        }
    }
}
