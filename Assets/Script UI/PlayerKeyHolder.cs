using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyHolder : MonoBehaviour
{

    [Header ("Key Attributes")]
    [SerializeField] private float startingAmountKey = 0; // initial amount of key
    public float currentAmountKey {get; set;}
    [SerializeField] private float maxAmountKey = 3; // initial amount of key

    // public bool IsInvincible {get; set private;}

    [Header ("UIManager")]
    [SerializeField] private UIManager uiManager;


    void Awake()
    {
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAmountKey = startingAmountKey;
    }


    public void KeyCounter(float singleKey){
        
        currentAmountKey = Mathf.Clamp(currentAmountKey + singleKey, startingAmountKey, maxAmountKey);
 
        if(currentAmountKey == maxAmountKey)   
        {
        
            // Win UI
            if(uiManager != null)
                uiManager.Win();
        }      


    }



}


