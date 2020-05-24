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
    public GameObject optionsMenu;
    public GameObject gameOverMenu;
    public GameObject survivedMenu;
    public PlayerAttack pAttack;
    public PlayerHealth pHealth;
    public MouseLook cursor;
    public InteractWithObjects objects;
    public GameObject invMenu;
    public GameObject tutorialPanel;

    public bool isInventoryOpen = false;
    public Text gameText;
    public Text healthText;
    public Text ammoText;
    public Text invHealth;
    public Text invDoll;
    public Text invBlueKey;
    public Text invGreenKey;
    public Text invPurpleKey;
    public Text invRedKey;
    public int health = 0;
    public int doll = 0;
    public int blueKey = 0;
    public int greenKey = 0;
    public int purpleKey = 0;
    public int redKey = 0;
    public bool gamePaused = false;
    public bool optionMenu = false;
    public bool finishedTutorial = false;

    public void ChangeTurorialTextColor(string t)
    {
        if(!finishedTutorial)
        {
            Text text = GameObject.Find(t).GetComponent<Text>();
            text.color = Color.gray;
        }
    }

    void Start()
    {
        UpdateInventory();
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

    public void OptionsMenu()
    {
        optionMenu = !optionMenu;
        if(optionMenu)
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Death()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        cursor.ChangeCursor();
    }

    IEnumerator Survived()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        survivedMenu.SetActive(true);
        cursor.ChangeCursor();
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ChangeTurorialTextColor("Text (4)");
            isInventoryOpen = !isInventoryOpen;
            if (isInventoryOpen)
            {
                invMenu.SetActive(true);
            }
            else
            {
                invMenu.SetActive(false);
            }
        }
    }

    public void UpdateInventory()
    {
        invHealth.text = "x" + health.ToString("D1");
        invDoll.text = "x" + doll.ToString("D1");
        invBlueKey.text = "x" + blueKey.ToString("D1");
        invGreenKey.text = "x" + greenKey.ToString("D1");
        invPurpleKey.text = "x" + purpleKey.ToString("D1");
        invRedKey.text = "x" + redKey.ToString("D1");
    }
    public void Message(string text)
    {
        string oldText = text;
        if (gameText.text != oldText)
        {
            StopCoroutine(ShowMessage(oldText));
            StartCoroutine(ReplaceMessage(text));
            return;
        }
        else
        {
            StartCoroutine(ShowMessage(text));
            return;
        }
    }

    IEnumerator ShowMessage(string text)
    {
            gameText.text = text;
            yield return new WaitForSeconds(3);
            gameText.text = "";
    }

    IEnumerator ReplaceMessage(string text)
    {
        gameText.text = text;
        yield return new WaitForSeconds(3);
        gameText.text = "";

    }
}
