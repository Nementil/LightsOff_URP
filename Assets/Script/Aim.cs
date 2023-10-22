using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera cam;
    Vector2 mousePos;
    Rigidbody2D rb;
    [SerializeField] float rangeLight = 5;
    [SerializeField] float angleLight = 90;
    [SerializeField] GameObject Lamp;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Lamp = transform.GetChild(0).gameObject;
        angleLight = Lamp.GetComponent<Light2D>().pointLightOuterAngle;
        rangeLight = Lamp.GetComponent<Light2D>().pointLightOuterRadius;
    }
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        //CheckEnemyInLight();

        //Vector3 directionlooking= transform.rotation *new Vector3(0,1,0);
        //Debug.DrawRay(transform.position, directionlooking, Color.red);
    }
    private void CheckEnemyInLight()
    {
        for(int angle=(int)Mathf.Floor(-angleLight/2); angle<angleLight/2;angle+=5)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle+ transform.rotation.eulerAngles.z);
            Vector3 direction= rotation*Vector3.up;
            Ray ray = new(Lamp.transform.position, direction);
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, direction, rangeLight);

            Debug.DrawRay(Lamp.transform.position, direction * 7, Color.red);
            for (var i=0;i<hit.Length;i++)
            {
                if(hit[i].collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy!");
                    //GameManager.Instance.enemiesKilled++;
                    Destroy(hit[i].collider.gameObject);
                }
            }
        }
    }
}