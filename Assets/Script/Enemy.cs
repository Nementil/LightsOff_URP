using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] SO_Enemy1 enemy;
    [SerializeField] GameObject container;
    private void Awake()
    {
        container = GameObject.FindWithTag("Instantiated Enemies");
    }
    private void OnDestroy()
    {
        foreach(var item in enemy.lootTable)
        {
            int randomNumber = Random.Range(0, 100);
            //Debug.Log($"Val:{randomNumber} vs {item.dropRate}");
            if(item.dropRate>randomNumber)
            {
                Instantiate(item.item, transform.position, Quaternion.identity, container.transform);
                break;
            }
            
        }
    }
}
