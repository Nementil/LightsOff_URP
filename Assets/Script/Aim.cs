using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public GameObject inputManager;
    [SerializeField] public PlayerActions playerActions;//see inputactions
    [SerializeField] private PlayerInput playerInput;//component
    [SerializeField] private InputAction aimAction;//action in map

    void Awake()
    {
        playerActions = new PlayerActions();
        playerInput = inputManager.GetComponent<PlayerInput>();
        playerActions.Keyboard.Enable();
        aimAction = playerInput.actions["Aim"];
        
    }
    public void OnAiming(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
}
