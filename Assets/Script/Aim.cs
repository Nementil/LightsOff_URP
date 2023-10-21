using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Aim : MonoBehaviour
{
    public Vector2 mousePos;
    public Vector2 aim_local;
    [SerializeField] private Camera cam;
    [SerializeField] public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    public void OnAiming(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //shoot = playerInputAction.Player.Shoot.ReadValue<float>();
        Vector2 lookDir = mousePos - rb.position;
        var angle = Mathf.Atan2(lookDir.y ,lookDir.x )* Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }
       
}
