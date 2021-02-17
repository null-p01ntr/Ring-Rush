using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject fill;
    public Slider slider;
    public Sprite[] healthICON;
    public GameObject healthIND;
    public Gradient grad;

    void Update()
    {
        if (Ring.health <= 12)
            fill.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        else fill.GetComponent<Image>().color = grad.Evaluate(Ring.health/100f);

        slider.value = Ring.health;

        if (Ring.health > 60)
            healthIND.GetComponent<Image>().sprite = healthICON[2];
        else if (Ring.health > 30)
            healthIND.GetComponent<Image>().sprite = healthICON[1];
        else if (Ring.health > 0)
            healthIND.GetComponent<Image>().sprite = healthICON[0];
    }
}