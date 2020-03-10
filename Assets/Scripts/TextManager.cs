using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class TextManager : IText
{       
    public Text text {
        get
        {
            GameObject objectParent = GameObject.Find("Canvas");
            GameObject text = objectParent.transform.Find("Text").gameObject;

            Text textObject = text.GetComponent<Text>();

            return textObject;
        }       
    }

    public TextManager()
    {
        
    }

    public void clearText()
    {
        this.text.text = "";
    }

    public void setText(string text)
    {
        this.text.text = text;
    }
}
