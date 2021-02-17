using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class festivalSpawner : MonoBehaviour
{
    static public bool inZone;

    void Start()
    {
        inZone = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Ring")
            inZone = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Ring")
            inZone = false;
    }
}
