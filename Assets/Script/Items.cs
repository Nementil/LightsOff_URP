using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public SO_Items item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //GameObject player=collision.gameObject.tag=="Player";
            //player.GetComponent<Battery>().battery++;
            Debug.Log("Item Collided");
            if(item.item.name=="Hearth")
            {
                if (collision.gameObject.GetComponent<PlayerHealth>().currentHealth<5) 
                {
                    collision.gameObject.GetComponent<PlayerHealth>().currentHealth++;
                    Destroy(this.gameObject);
                }
            }
        }
    }
    
}
