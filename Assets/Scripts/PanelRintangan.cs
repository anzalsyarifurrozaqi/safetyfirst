using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRintangan : MonoBehaviour
{
    public Text text
    {
        get
        {            
            GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Panel2").gameObject;

            GameObject textObject = panelGameObject.transform.Find("Text").gameObject;
            Text textPanel = textObject.GetComponent<Text>();

            return textPanel;
        }
    }

    public void openPanel()
    {        
        GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Panel2").gameObject;

        GameObject textObject = panelGameObject.transform.Find("Text").gameObject;
        Text textPanel = textObject.GetComponent<Text>();        

        panelGameObject.SetActive(true);
    }

    public void closePanel()
    {        
        GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Panel2").gameObject;        

        panelGameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        this.text.text = "";
        this.text.text = text;        
    }   
}
