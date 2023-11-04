using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float cooldown;
    [SerializeField] public float cooldown_val;
    [SerializeField] public float range;
    [SerializeField] public float rangeMinimum;
    [SerializeField] public List<GameObject> enemyList_prefab;
    [SerializeField] public GameObject container;
    //[SerializeField] public GameObject prefab;

    private void Start()
    {
        cooldown = cooldown_val;
        container = GameObject.FindWithTag("Instantiated Enemies");
    }
    private void Update()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            if(InRangePlayer())
            {
                InstantiateEnemy();
            }
            cooldown = cooldown_val;
        }
    }

    /*
    private void FixedUpdate()
    {
        if (enemiesInstantiated < maxEnemies)
        {
            containerSpawner.transform.GetChild(UnityEngine.Random.Range(0, containerSpawner.transform.childCount)).gameObject.GetComponent<Spawner>();
        }
    }
    */
    public void InstantiateEnemy()
    {
        //raycast range
        GameObject enemy=Instantiate(enemyList_prefab[Random.Range(0, enemyList_prefab.Count)],transform.position,Quaternion.identity,container.transform);
        GameManager._instance.enemiesInstantiated++;

    }
    public bool InRangePlayer()
    {
        for (int angle =0; angle < 360; angle += 5)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle + transform.rotation.eulerAngles.z);
            Vector3 direction = rotation * Vector3.up;
            
            Ray ray = new(transform.position, direction);
            RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, direction, range);

            
            for (var i = 0; i < hit.Length; i++)
            {
                Debug.DrawRay(transform.position, direction * hit[i].distance, Color.blue, 3f);
                if (hit[i].collider.gameObject.CompareTag("Wall"))
                {
                    break;
                }
                if (hit[i].collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Enemy!");
                    //GameManager.Instance.enemiesKilled++;
                    if(hit[i].distance<rangeMinimum)
                    {
                        return false;
                    }
                    return true;
                }

            }
        }
        return false;
    }
}
