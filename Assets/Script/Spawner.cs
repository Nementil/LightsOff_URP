using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public float cooldown_val;
    [SerializeField] public float cooldown;
    [SerializeField] public List<SO_Enemy1> enemyList;
    [SerializeField] public GameObject container;
    [SerializeField] public GameObject prefab;

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
            //if (GameManager._instance.enemiesInstantiated < GameManager._instance.maxEnemies)
            Debug.Log("hello");
            {
                GameObject Enemy=Instantiate(prefab,transform.position,Quaternion.identity,container.transform);
                prefab.GetComponent<Enemy>().enemy=enemyList[Random.Range(0, enemyList.Count)];
                prefab.GetComponent<EnemyAI>().enemy = enemyList[Random.Range(0, enemyList.Count)];
            }
            cooldown = cooldown_val;
        }
    }
}
