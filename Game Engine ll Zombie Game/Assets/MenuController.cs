using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public string mainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;

    public GameObject optionsMenu;
    
    
    void Start()
    {
        
    }

  
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }


    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);

    }

    public void ActivateOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ApplyChanges()
    {
        ReturnToPauseScreen();
    }

    public void CancelChanges()
    {
        ReturnToPauseScreen();
    }

    public void ReturnToPauseScreen()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
           
}
