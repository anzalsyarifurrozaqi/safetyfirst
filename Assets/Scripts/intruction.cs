using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intruction : MonoBehaviour
{    
    private TextManager _textManager;
    string[] textData = { "Swipe ke kanan dan kiri untuk belok", "Swipe kebawah kemudian tahan untuk rem","tap ikon bensin untuk menambah energi"};
    public int i = 0;
    PanelRintangan panelRintangan;
  
    private void Start()
    {
        //_textManager = new TextManager();        
        GameObject rintanganObject = new GameObject();
        rintanganObject.AddComponent<PanelRintangan>();
        panelRintangan = rintanganObject.GetComponent<PanelRintangan>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("inst");            
            panelRintangan.openPanel();            
            StartCoroutine(IntructionTiming());
        }
    }
    IEnumerator IntructionTiming()
    {
        panelRintangan.SetText(textData[i]);
        yield return new WaitForSeconds(2f);
        //_textManager.clearText();        
        panelRintangan.closePanel();        
    }
}
