using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public SO_Items item;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //GameObject player=collision.gameObject.tag=="Player";
            //player.GetComponent<Battery>().battery++;
            Debug.Log("Item Collided");
            Destroy(this.gameObject);
        }
    }
}
