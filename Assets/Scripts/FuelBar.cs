using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{   
    public float bar;
    static float max = 100;
    Image FuelBarImg;

    void Start()
    {       
        FuelBarImg = GetComponent<Image>();
        bar = max;
    }
    void Update()
    {
        FuelBarImg.fillAmount = bar / 100;
        if(FindObjectOfType<Entity>().speed > 0 && (bar/max) > 0 )
            bar -= (0.01f * FindObjectOfType<Entity>().speed);
    }

    public void takeAmount(float val)
    {
        bar += val;
    }    
}
