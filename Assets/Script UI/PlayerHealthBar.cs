using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// UI CANVAS SCRIPT
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        if(playerHealth == null){
            playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }
    }


    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;

        if(playerHealth == null){
            playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }
    }
}
