using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance=> _instance;
    public GameManagerState State;
    public int enemiesKilled;
    public int enemiesInstantiated;
    public bool doorUnlocked = false;
    public bool cutscene_active;
    private int timeInterval;
    [SerializeField] private AudioManager audioInstance;
    [SerializeField] public int maxEnemies;
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject audioManager; 

    private void Awake() 
    {
        if(_instance!=null && _instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance=this;
        }
        if(audioManager==null)
        {
            audioManager = GameObject.FindWithTag("AudioManager");
            audioInstance = AudioManager._instance;
        }
        if (player == null) 
        { 
            player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerMovement2>().enabled=false;
        }
    }

    private void Start() 
    {
        UpdateGameState(GameManagerState.cutscene);
    }

    private void Update() 
    {
        if(State == GameManagerState.cutscene)
        {
            audioInstance.AudioEnable(audioInstance.AudioSources[0]);
          
            if (!cutscene_active) 
            {
                audioInstance.AudioDisable(audioInstance.AudioSources[0]);
                audioInstance.AudioEnable(audioInstance.AudioSources[1]);
                UpdateGameState(GameManagerState.init);
            }
        }
        
        if(State==GameManagerState.init)
        {
            player.GetComponent<PlayerMovement2>().enabled = true;
            UpdateGameState(GameManagerState.loop);
        }

        if(State==GameManagerState.loop)
        {
            //if(player.GetComponent<Health>().hp=<0)
            {
              //  UpdateGameState(GameManagerState.end);
            }
            if(doorUnlocked)
            {
                UpdateGameState(GameManagerState.win);
            }
        }
        if(State==GameManagerState.end)
        {
            //SHOW MESSAGE+SCORE ->BACK TO MENU
        }
        if(State==GameManagerState.win)
        {
            //CHANGE SCENE FROM ENUM/PREDEFINED ARRAY
        }
    }

    public void UpdateGameState(GameManagerState newState)
    {
        State=newState;
        switch(State)
        {
            case GameManagerState.init:
            Debug.Log($"<color=yellow>Init State</color>");
            break;
            case GameManagerState.loop:
            Debug.Log($"<color=yellow>Loop State</color>");
            break;
            case GameManagerState.end:
            Debug.Log($"<color=yellow>End State</color>");
            break;
        }
    }
    public enum GameManagerState
    {
        cutscene,
        init,
        loop,
        end,
        win
    }


        public static GameManager instance; // An instance from the GameManager Class
    // public string[] sceneNames = { "Room1", "Room2", "Room3", "Menu" };
    // private int currentSceneIndex = 0;
    // [SerializeField] private GameObject gameOverScreen; 
    // [SerializeField] private GameObject pauseScreen; 
    // [SerializeField] private GameObject mainMenu;

    // public UIManager uiManager; 

    // public void Awake()
    // {

    //     if (instance == null) 
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject); 
    //     }
    // }

}
