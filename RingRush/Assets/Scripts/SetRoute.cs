using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoute : MonoBehaviour
{
    static public int Route;
    public GameObject[] Barriers; 
    public GameObject[] Routes; 
    public Sprite[] barrOff;
    public Sprite[] barrOn;
    void Start()
    {
        Route = 0;
    }
    void Update()
    {
        switch (Route)
        {
            case 0:
                Barriers[0].GetComponent<SpriteRenderer>().sprite = barrOn[0];
                Barriers[4].GetComponent<SpriteRenderer>().sprite = barrOn[2];
                Barriers[1].GetComponent<SpriteRenderer>().sprite = barrOff[0];                
                Barriers[5].GetComponent<SpriteRenderer>().sprite = barrOff[3];                
                Barriers[2].GetComponent<SpriteRenderer>().sprite = barrOn[0];
                Barriers[3].GetComponent<SpriteRenderer>().sprite = barrOn[1];

                Barriers[0].GetComponent<BoxCollider2D>().enabled = true;
                Barriers[4].GetComponent<BoxCollider2D>().enabled = true;
                Barriers[1].GetComponent<BoxCollider2D>().enabled = false;
                Barriers[5].GetComponent<BoxCollider2D>().enabled = false;
                Barriers[2].GetComponent<BoxCollider2D>().enabled = true;
                Barriers[3].GetComponent<BoxCollider2D>().enabled = true;

                Routes[0].gameObject.SetActive(true);
                Routes[1].gameObject.SetActive(false);
                break;

            case 1:
                Barriers[0].GetComponent<SpriteRenderer>().sprite = barrOff[0];
                Barriers[4].GetComponent<SpriteRenderer>().sprite = barrOff[2];
                Barriers[1].GetComponent<SpriteRenderer>().sprite = barrOn[0];
                Barriers[5].GetComponent<SpriteRenderer>().sprite = barrOn[3];
                Barriers[2].GetComponent<SpriteRenderer>().sprite = barrOff[0];
                Barriers[3].GetComponent<SpriteRenderer>().sprite = barrOff[1];

                Barriers[0].GetComponent<BoxCollider2D>().enabled = false;
                Barriers[4].GetComponent<BoxCollider2D>().enabled = false;
                Barriers[1].GetComponent<BoxCollider2D>().enabled = true;
                Barriers[5].GetComponent<BoxCollider2D>().enabled = true;
                Barriers[2].GetComponent<BoxCollider2D>().enabled = false;
                Barriers[3].GetComponent<BoxCollider2D>().enabled = false;

                Routes[0].gameObject.SetActive(false);
                Routes[1].gameObject.SetActive(true);
                break;
        }

        //switch route condition
        if (Timer.timeLeft < 60)
            Route = 1;
        else Route = 0;
    }
}
