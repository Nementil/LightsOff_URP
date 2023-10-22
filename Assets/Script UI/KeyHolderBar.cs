using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolderBar : MonoBehaviour
{
    [SerializeField] private Image totalKeyBar;
    [SerializeField] private Image currentKeyBar;
    public PlayerKeyHolder playerKeyHolder;

    // Start is called before the first frame update
    void Awake()
    {
        if(playerKeyHolder == null){
            playerKeyHolder = GameObject.FindWithTag("Player").GetComponent<PlayerKeyHolder>();
        }
    }


    void Start()
    {
        totalKeyBar.fillAmount = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        totalKeyBar.fillAmount = 0.3f;
        currentKeyBar.fillAmount = playerKeyHolder.currentAmountKey / 10;

        if(playerKeyHolder == null){
            playerKeyHolder = GameObject.FindWithTag("Player").GetComponent<PlayerKeyHolder>();
        }
    }
}
