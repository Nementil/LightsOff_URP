using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    Vector2 mousePos;
    Rigidbody2D rb;

    private void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}