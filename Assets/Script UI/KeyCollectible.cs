using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{

    public PlayerKeyHolder playerKeyHolder; // Change "PlayerKeyHolder" to "PlayerkeyHolder"
    private bool isCollected = false;
    private void Awake()
    {
        playerKeyHolder = GameObject.FindWithTag("Player").GetComponent<PlayerKeyHolder>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerKeyHolder != null && !isCollected) 
        {
            Debug.Log("Key collected");
            playerKeyHolder.KeyCounter(1);
            isCollected=true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<KeyCollectible>().enabled = false;
        }
    }
}
