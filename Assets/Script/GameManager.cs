using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance=> _instance;
    public GameManagerState State;
    private int enemiesKilled;
    private int timeInterval;
    [SerializeField] private GameObject player;
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
    }

    private void Start() 
    {
        UpdateGameState(GameManagerState.init);
    }

    private void Update() 
    {
        if(State==GameManagerState.init)
        {
            
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
        init,
        loop,
        end
    }
}
