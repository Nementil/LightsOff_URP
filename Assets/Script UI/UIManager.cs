using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen; 
    [SerializeField] private GameObject pauseScreen; 
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject playerHealthBar;
    [SerializeField] private GameObject keyHolderBar;
    // public GameObject mainCam;


    private void Awake()
    {

        if(gameOverScreen != null && pauseScreen != null &&
        playerHealthBar != null && keyHolderBar != null && winMenu != null)
        {
            gameOverScreen.SetActive(false);
            pauseScreen.SetActive(false);
            playerHealthBar.SetActive(false);
            keyHolderBar.SetActive(false);
            winMenu.SetActive(false);
        }

        

    }

    // GAME OVER BUTTON //
    public void GameOver()
    {   
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }


    // PAUSE BUTTONS //

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Vérifiez le nom de la scène actuelle
        if (currentScene.name == "Map1")
        {
            // Remove Main Menu
            mainMenu.SetActive(false);
            playerHealthBar.SetActive(true);
            keyHolderBar.SetActive(true);

            // Pause
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseScreen.activeInHierarchy)
                    PauseMenu(true);
                else
                    PauseMenu(false);
            }
            // GameOver
            // if (Input.GetKeyDown(KeyCode.G))
            // {
            //     GameOver();
            // }
        }else if(currentScene.name == "Menu")
        {
            mainMenu.SetActive(true);
            playerHealthBar.SetActive(false);
            keyHolderBar.SetActive(false);
            gameOverScreen.SetActive(false); 
            pauseScreen.SetActive(false);
        }

    }
    

    public void PauseMenu(bool statut)
    {
        pauseScreen.SetActive(statut);

        // Freeze time while in Pause Menu
        Time.timeScale = System.Convert.ToInt32(!statut);
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 0;
    }



    // MAIN MENU BUTTONS //
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        gameOverScreen.SetActive(false);
        winMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Exit option for editor 
        #endif
    }

}
