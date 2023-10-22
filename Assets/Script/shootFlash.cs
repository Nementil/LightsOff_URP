using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class shootFlash : MonoBehaviour
{
    public float Luminance = 0;
    private bool isGrowing = false;

    [SerializeField] float rangeLight = 5;
    [SerializeField] float angleLight = 90;

    [SerializeField, Range(0f, 10f)] private float growthRate = 1.0f;
    [SerializeField, Range(0f, 100f)] private float LuminanceMax = 10.0f;

    private List<GameObject> hitEnemies = new List<GameObject>();

    private void Awake()
    {
        angleLight = transform.GetComponent<Light2D>().pointLightOuterAngle;
        rangeLight = transform.GetComponent<Light2D>().pointLightOuterRadius;
    }

    private void Update()
    {
        // Check if the "Fire" button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isGrowing)
            {
                StartCoroutine(GrowLuminance());
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(GrowLuminance());
            GetComponent<intensityController>().Flash(Luminance);
            isGrowing = false;
            Luminance = 0;
            ShootRaycasts();
            

        }
    }
 
    private void ShootRaycasts()
    {
        /*
        Vector3 forwardDirection = transform.up; // Use the object's forward direction based on rotation

        List<Vector3> raycastDirections = new List<Vector3>
        {
            forwardDirection,
            Quaternion.Euler(0, 0, 5) * forwardDirection, // Rotate 5 degrees to the right
            Quaternion.Euler(0, 0, -5) * forwardDirection, // Rotate 5 degrees to the left
        };

        hitEnemies.Clear(); // Clear the list before storing new hits

        foreach (var direction in raycastDirections)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);

            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hitEnemies.Add(hit.transform.gameObject);
                }
            }
            Debug.DrawRay(transform.position, direction * 10, Color.red, 0.1f);
        }

        Debug.Log("Shoot !");

        // Handle the hitEnemies list as needed (e.g., apply damage, destroy, etc.)
        */
        for (int angle = (int)Mathf.Floor(-angleLight / 2); angle < angleLight / 2; angle += 5)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle + transform.rotation.eulerAngles.z);
            Vector3 direction = rotation * Vector3.up;
            Ray ray = new(transform.position, direction);
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, direction, rangeLight);

            Debug.DrawRay(transform.position, direction * rangeLight, Color.red);
            for (var i = 0; i < hit.Length; i++)
            {
                if(hit[i].collider.gameObject.CompareTag("Wall"))
                {
                    break;
                }
                if (hit[i].collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy!");
                    //GameManager.Instance.enemiesKilled++;
                    Destroy(hit[i].collider.gameObject);
                }

                Debug.DrawRay(transform.position, direction * 10, Color.red, 0.1f);
            }
        }
    }

    private IEnumerator GrowLuminance()
    {
        isGrowing = true;
        float startValue = Luminance;
        float endTime = Time.time + growthRate;

        while (Time.time < endTime)
        {
            float t = 1 - ((endTime - Time.time) / growthRate); // Calculate a normalized time value from 0 to 1
            Luminance = Mathf.Lerp(startValue, LuminanceMax, t * t); // Apply an ease-in function (t * t for simplicity)

            Debug.Log(Luminance);

            yield return null;
        }

        Luminance = LuminanceMax; // Ensure the value reaches the threshold exactly
    }
}
