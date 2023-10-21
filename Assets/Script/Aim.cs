using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    Vector2 mousePos;
    Rigidbody2D rb;
    private bool connected = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CheckForControllers());

    }
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position; //connected ? new Vector2(Input.GetAxis("HorizontalRight"), -Input.GetAxis("VerticalRight")) : mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

   

    IEnumerator CheckForControllers()
    {
        while (true)
        {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0)
            {
                connected = true;
                Debug.Log("Connected");

            }
            else if (connected && controllers.Length == 0)
            {
                connected = false;
                Debug.Log("Disconnected");
            }

            yield return new WaitForSeconds(1f);
        }
    }
}