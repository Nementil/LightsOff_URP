using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; set;}
    // public bool IsInvincible {get; set private;}
    private bool dead = false;


    [Header ("IFrames")]
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float iframesDuration;
    private SpriteRenderer sr;

    [Header ("UIManager")]
    [SerializeField] private UIManager uiManager;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth; // Full Player health 
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, startingHealth);
        
    }
    public void TakeDamage(float damage){

        currentHealth -= damage;
        if(currentHealth > 0){
            
            //IFrames
            StartCoroutine(Invulnerability());

        }else{
            if(!dead){
                gameObject.SetActive(false);
                dead = true;
                 
                // Game Over UI
                if(uiManager != null)
                    uiManager.GameOver();
            }  
        }
    }


    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7, true);


        for(int i = 0; i < numberOfFlashes; i++){

            sr.color = new Color(0.87f, 0, 0, 0.5f);

            yield return new WaitForSeconds(iframesDuration);

            sr.color = new Color(1, 1, 1, 1);

            yield return new WaitForSeconds(iframesDuration);

        }   

        Physics2D.IgnoreLayerCollision(6,7, false);
    }
}
