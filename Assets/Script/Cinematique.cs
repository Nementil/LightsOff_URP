using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematique : MonoBehaviour
{
    [SerializeField] public List<GameObject> cinematiques;
    [SerializeField] public float temps =3f;
    private float compteur_temps;
    int counter=0;

    void Awake()
    {
        //Time.timeScale = 0;
        GameManager._instance.cutscene_active = true;
        cinematiques[0].SetActive(true);
        cinematiques[1].SetActive(false);
        cinematiques[2].SetActive(false);
        cinematiques[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            GetComponent<AudioSource>().Stop();
            cinematiques[0].SetActive(false);
            cinematiques[1].SetActive(false);
            cinematiques[2].SetActive(false);
            cinematiques[3].SetActive(false);
            gameObject.SetActive(false);
        }
        if(compteur_temps>0)
        {
            compteur_temps -= Time.deltaTime;
        }
        else if (counter == 4)
        {
            //Time.timeScale = 1;
            GameManager._instance.cutscene_active = false;
            gameObject.SetActive(false);
        }
        else
        {
            counter++;
            foreach(GameObject image in cinematiques) 
            { 
                image.SetActive(false); 
            }
            cinematiques[counter].SetActive(true);
            compteur_temps = temps;
        }

    }
}
