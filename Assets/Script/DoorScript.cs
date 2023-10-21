using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    
    void Update()
    {
        
  
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            anim.SetTrigger("OpenDoor");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("CloseDoor");
    }

}
