using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampuPanel : MonoBehaviour
{
    public Image image
    {
        get
        {
            GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Lampu Lalulintas").gameObject;

            GameObject colObject = panelGameObject.transform.Find("Panel").gameObject;
            Image col = colObject.GetComponent<Image>();

            return col;
        }
    }

    public void displayLampu()
    {
        GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Lampu Lalulintas").gameObject;

        GameObject colObject = panelGameObject.transform.Find("Panel").gameObject;        

        colObject.SetActive(true);
    }

    public void closeLampu()
    {
        GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Lampu Lalulintas").gameObject;

        GameObject colObject = panelGameObject.transform.Find("Panel").gameObject;

        colObject.SetActive(false);
    }

    public void SetColor(Color col)
    {
        this.image.color = col;
    }
}
