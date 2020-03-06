using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public PlayerAttack pAttack;
    public PlayerHealth pHealth;
    public MouseLook cursor;
    public InteractWithObjects objects;

    public bool gamePaused = false;
    public Text gameText;
    public Text healthText;
    public Text ammoText;
    public Text dollText;
 
    void Start()
    {
        gameText.text = "Pick up the gun behind you using E";
    }

    void Update()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeStartingMessage(int i)
    {
        if(gameText.text == "Pick up the gun behind you using E" && i ==1)
        {
            gameText.text = "Press 2 to use pistol";
            return;
        }
        if (gameText.text == "Press 2 to use pistol" && i == 2)
        {
            gameText.text = "Go kill zombie!!!";
            return;
        }
        if (gameText.text == "Go kill zombie!!!" && i == 3)
        {
            gameText.text = "";
            return;
        }
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        if(gamePaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            cursor.ChangeCursor();
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            cursor.ChangeCursor();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        gameOverMenu.SetActive(false);
    }

    public void FoundDoll()
    {
        if (objects.doll1)
        {
            dollText.text = "1/2 dolls found";
        }
        if (objects.doll2)
        {
            dollText.text = "All dolls found!";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Death()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        cursor.ChangeCursor();
    }
}
