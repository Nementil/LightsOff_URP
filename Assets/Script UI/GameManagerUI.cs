using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    public static GameManagerUI instance; // An instance from the GameManager Class
    // public string[] sceneNames = { "Room1", "Room2", "Room3", "Menu" };
    // private int currentSceneIndex = 0;
    // [SerializeField] private GameObject gameOverScreen; 
    // [SerializeField] private GameObject pauseScreen; 
    // [SerializeField] private GameObject mainMenu;

    // public UIManager uiManager; 

    public void Awake()
    {

        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Duplicate UI:Destroy");
            Destroy(gameObject); 
        }
    }


}
