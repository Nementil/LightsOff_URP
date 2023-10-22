using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique : MonoBehaviour
{
    [SerializeField] public List<GameObject> cinematiques;
    float temps =3f;
    int counter=0;

    void Awake()
    {
        //Time.timeScale = 0;
        cinematiques[0].SetActive(true);
        cinematiques[1].SetActive(false);
        cinematiques[2].SetActive(false);
        cinematiques[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(temps>0)
        {
            temps -= Time.deltaTime;
        }
        else
        {
            counter++;
            cinematiques[0].SetActive(false);
            cinematiques[1].SetActive(false);
            cinematiques[2].SetActive(false);
            cinematiques[3].SetActive(false);
            cinematiques[counter].SetActive(true);
            temps = 3;
        }
        if (counter == 4)
        {
            //Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
