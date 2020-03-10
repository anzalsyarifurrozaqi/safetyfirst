using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intruction : MonoBehaviour
{    
    private TextManager _textManager;
    string[] textData = { "Swipe ke kanan dan kiri untuk belok", "Swipe kebawah untuk rem" };
    int i = 0;
    
    private void Start()
    {
        _textManager = new TextManager();        
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("instruction"))
        {           
            StartCoroutine(IntructionTiming());
        }
    }

    IEnumerator IntructionTiming()
    {
        _textManager.setText(textData[i]);
        yield return new WaitForSeconds(2f);
        _textManager.clearText();
        i += 1;
    }
}
