using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class intensityController : MonoBehaviour
{
    [SerializeField, Range(1f, 4f)] float luminanceMin = 3f;
    [SerializeField, Range(0f, 10f)] private float dimRate = 1.0f;
    float luminanceMax;
    Light2D light;
    // Start is called before the first frame update
    void Awake()
    {
        luminanceMax = 10f;//GetComponent<shootFlash>().LuminanceMax;
        light = GetComponent<Light2D>();
        light.intensity = luminanceMin;
    }

    // Update is called once per frame
    void Flash(float lum)
    {
        light.intensity = Mathf.Clamp(lum,luminanceMin,luminanceMax);
        StartCoroutine(DimLight(lum));
    }

    private IEnumerator DimLight(float Luminance) 
    {
        float startValue = Luminance;
        float endTime = Time.time + dimRate;

        while (Time.time < endTime)
        {
            float t = 1 - ((endTime - Time.time) / dimRate); // Calculate a normalized time value from 0 to 1
            Luminance = Mathf.Lerp(startValue, luminanceMin, t); // Apply an ease-in function (t * t for simplicity)

            light.intensity = Luminance;

            yield return null;
        }

        Luminance = luminanceMin; // Ensure the value reaches the threshold exactly
    }
}
