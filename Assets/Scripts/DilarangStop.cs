using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilarangStop : MonoBehaviour
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
            _textManager.setText("memasuki jalur Dilarang Stop");
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
            Debug.Log("exit jalur stop");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("stay jalur stop");
        }
    }

    private IEnumerator gagal(float limitTime)
    {
        while (true)
        {
            if (Mathf.Round((_entity.playerSpeed * 12)) == 0)
            {
                limitTime += Time.fixedDeltaTime;
            }
            else
            {
                limitTime = 0f;
            }
            yield return null;
            //Debug.Log($"limit time {limitTime}");
            if (limitTime > 2f)
            {
                Debug.Log("gagal");
                GameObject newObject = new GameObject();
                newObject.AddComponent<Panel>();
                Panel panel = newObject.GetComponent<Panel>();
                panel.SetText("GAGAL", "DILARANG STOP");
                panel.openPanel();
                StopAllCoroutines();
            }

        }
    }
}
