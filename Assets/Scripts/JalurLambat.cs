using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalurLambat : MonoBehaviour, IRambu
{
    private TextManager _textManager;
    private IEntity _entity;    

    private void Start()
    {
        _textManager = new TextManager();
        _entity = Entity.Instance;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        float limitTime = 0f;
        if (other.CompareTag("Player"))
        {
            _textManager.setText("memasuki jalur lambat, tidak boleh lebih dari 50 km / jam");
            StartCoroutine(gagal(limitTime));
            Debug.Log("jalur lambat");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _textManager.clearText();
            StopAllCoroutines();
            Debug.Log("exit jalur lambat");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {            
            Debug.Log("stay jalur lambat");
        }
    }

    private IEnumerator gagal(float limitTime)
    {       
        while(true)
        {
            if (Mathf.Round((_entity.playerSpeed * 12)) > 50)
            {
                limitTime += Time.fixedDeltaTime;
            }                
            else
            {
                limitTime = 0f;                
            }
            yield return null;
            Debug.Log($"limit time {limitTime}");
            if (limitTime > 3f)
            {                
                Debug.Log("gagal");
                GameObject newObject = new GameObject();
                newObject.AddComponent<Panel>();
                Panel panel = newObject.GetComponent<Panel>();
                panel.SetText("GAGAL", "KECEPATAN TIDAK BOLEH LEBIH DARI 50 KM / JAM");
                panel.openPanel();
                StopAllCoroutines();
            }

        }                        
    }
}
