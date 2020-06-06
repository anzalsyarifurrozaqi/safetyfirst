using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    string text, text2;
    
    public void openPanel()
    {
        Time.timeScale = 0;

        GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
       
        GameObject textObject = panelGameObject.transform.Find("Text").gameObject;
        Text textPanel = textObject.GetComponent<Text>();
        textPanel.text = text;

        GameObject textObject2 = panelGameObject.transform.Find("Text2").gameObject;
        Text textPanel2 = textObject2.GetComponent<Text>();
        textPanel2.text = text2;

        panelGameObject.SetActive(true);
    }

    public void SetText(string text, string text2 = null)
    {
        if (text == "SUKSES")
        {
            GameObject panelGameObject = GameObject.Find("Canvas").transform.Find("Panel").gameObject;

            GameObject textObject = panelGameObject.transform.Find("Text").gameObject;
            Text textPanel = textObject.GetComponent<Text>();
            textPanel.color = Color.green;
        }
        this.text = text;
        this.text2 = text2;

        
    }
}
